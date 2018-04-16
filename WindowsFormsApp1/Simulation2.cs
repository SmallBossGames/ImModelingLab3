using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Simulation2
    {
        public Statistic Simulate(double fullTime)
        {
            var timeScale = 0.0;
            var shipQueue = new ShipQueue();
            var storm = new Storm();
            var toWork = new ToWork();
            var statistic = new Statistic(3);

            IQuest[] quests = { shipQueue, storm, toWork };

            shipQueue.Init(toWork);
            toWork.Init(shipQueue, storm, statistic, null);

            while (timeScale < fullTime)
            {
                Array.Sort(quests);
                for (int i = 0; i < quests.Length; i++)
                {
                    if (quests[i].EndTime > timeScale)
                        timeScale = quests[i].EndTime;

                    if (quests[i].TryMake(timeScale)) break;
                }
            }
            return statistic;
        }

        public Statistic SimulateWihFifeShips(double fullTime)
        {
            var timeScale = 0.0;
            var shipQueue = new ShipQueue();
            var storm = new Storm();
            var toWork = new ToWork();
            var fifeShips = new FifeShips();
            var statistic = new Statistic(4);

            IQuest[] quests = { shipQueue, storm, toWork, fifeShips };

            shipQueue.Init(toWork);
            toWork.Init(shipQueue, storm, statistic, fifeShips);
            fifeShips.Init(shipQueue);
            
            while (timeScale < fullTime)
            {
                Array.Sort(quests);
                for (int i = 0; i < quests.Length; i++)
                {
                    if (quests[i].EndTime > timeScale)
                        timeScale = quests[i].EndTime;
                    if (quests[i].TryMake(timeScale)) break;
                }
            }
            return statistic;
        }
    }

    public class Statistic
    {
        readonly int typeCount;

        int count = 0;
        double fullTime = 0.0;
        double[] inDockTimes;
        double[] fullTimes;
        int[] counts;

        public int Count => count;
        //public double FullTime => fullTime;
        public double MiddleFullTime => fullTime / count;
        public double MiddleInQueueTime => throw new Exception();

        public void IncCounter() => count++;
        public void AddFullTime(double time) => fullTime += time;

        public void AddShipData(double timeScale, Ship ship)
        {
            inDockTimes[ship.Type] += ship.InDockTime;
            fullTimes[ship.Type] += timeScale - ship.CreateTime;
            counts[ship.Type]++;
        }

        public double GetInDockMiddleShipTime(int index) => inDockTimes[index] / counts[index];
        public double GetWaitingMiddleShipTime(int index)  => (fullTimes[index] - inDockTimes[index]) / counts[index];
        public double GetFullMiddleShipTime(int index) => fullTimes[index];
        public int GetShipCount(int index) => counts[index];

        public Statistic(int typeCount)
        {
            this.typeCount = typeCount;
            inDockTimes = new double[typeCount];
            counts = new int[typeCount];
            fullTimes = new double[typeCount];
            for (int i = 0; i < typeCount; i++)
            {
                inDockTimes[i] = 0.0;
                fullTimes[i] = 0.0;
                counts[i] = 0;
            }
        }

        public class Ship : IComparable<Ship>
        {
            double createTime;
            double inDockTime;
            byte type;

            public Ship(double createTime, byte type)
            {
                this.createTime = createTime;
                this.type = type;
                inDockTime = KEK.GetLoadTime(type);
            }

            public double CreateTime => createTime;
            public double InDockTime => inDockTime;
            public byte Type => type;
            public double EndingTime { get; set; }

            public int CompareTo(Ship other)
            {
                return EndingTime.CompareTo(other.EndingTime);
            }
        }
    }

    class ShipQueue : IQuest
    {
        private const double interval = 17.0;
        private double endTime;
        Queue<Statistic.Ship> shipQueue;
        public ToWork toWork;

        public Queue<Statistic.Ship> ThisQueue => shipQueue;
        public double EndTime => endTime;

        public void Init(ToWork toWork)
        {
            this.toWork = toWork;
        }

        public ShipQueue()
        {
            endTime = interval;
            shipQueue = new Queue<Statistic.Ship>();
        }

        public void AddShip(Statistic.Ship ship, double timeScale)
        {
            shipQueue.Enqueue(ship);
            toWork.PushShip(timeScale);
        }

        public bool TryMake(double timeScale)
        {
            endTime = timeScale + interval;
            AddShip(new Statistic.Ship(timeScale, KEK.GenShips()), timeScale);
            return true;
        }

        public int CompareTo(IQuest other) => EndTime.CompareTo(other.EndTime);
    }

    class Storm : IQuest
    {
        const double stormMath = 48.0;

        private double endTime;
        bool isStorm;

        public double EndTime => endTime;

        public bool IsStorm => isStorm;

        public Storm()
        {
            isStorm = false;
            endTime = KEK.QStorm(stormMath);
        }

        public int CompareTo(IQuest other)
        {
            return EndTime.CompareTo(other.EndTime);
        }

        public bool TryMake(double timeScale)
        {
            if (!isStorm)
            {
                isStorm = true;
                endTime = timeScale + KEK.GetStorm();
            }
            else
            {
                isStorm = false;
                endTime = timeScale + KEK.QStorm(stormMath);
            }
            return true;
        }
    }

    class ToWork : IQuest
    {
        private double endTime;
        public double EndTime => endTime;

        public ShipQueue shipQueue;
        public Storm storm;
        public Statistic statistic;
        public FifeShips fifeShips;

        private List<Statistic.Ship> dock = new List<Statistic.Ship>(3);

        public void Init(ShipQueue shipQueue, Storm storm, Statistic statistic, FifeShips fifeShips)
        {
            this.shipQueue = shipQueue;
            this.storm = storm;
            this.statistic = statistic;
            this.fifeShips = fifeShips;
        }

        public bool PushShip(double timeScale)
        {
            if (storm.IsStorm) return false;
            if (shipQueue.ThisQueue.Count != 0 && dock.Count <= 3)
            {
                var pool = shipQueue.ThisQueue.Dequeue();
                pool.EndingTime = timeScale + pool.InDockTime;

                dock.Add(pool);
                dock.Sort();

                if (dock.Count != 0)
                    endTime = dock[0].EndingTime;
                else
                    endTime = -1.0;
                return true;
            }
            return false;
        }

        public bool PopShip(double timeScale)
        {
            if ((storm.IsStorm)||(dock.Count == 0)) return false;

            statistic.IncCounter();
            statistic.AddFullTime(timeScale - dock[0].CreateTime);

            statistic.AddShipData(timeScale, dock[0]);

            if (dock[0].Type==3)
            {
                fifeShips.PushShip(timeScale);
            }

            dock.RemoveAt(0);

            if (dock.Count != 0)
                endTime = dock[0].EndingTime;
            else
                endTime = -1.0;
            PushShip(timeScale);
            return false;
        }

        public int CompareTo(IQuest other) => EndTime.CompareTo(other.EndTime);

        public bool TryMake(double timeScale) => PopShip(timeScale);
    }

    class FifeShips : IQuest
    {
        const int shipCount = 5;
        double endTime = 0.0;

        ShipQueue shipQueue;

        List<double> nextShipTimes = new List<double>();

        public FifeShips()
        {
            for (int i = 0; i < shipCount; i++)
                nextShipTimes.Add(0.0);

            nextShipTimes.Sort();
        }

        public void Init(ShipQueue shipQueue)
        {
            this.shipQueue = shipQueue;
        }

        public bool PushShip(double timeScale)
        {
            if (shipCount <= nextShipTimes.Count) return false;

            nextShipTimes.Add(timeScale + KEK.GetShipRespawnTime());
            endTime = nextShipTimes[0];
            return true;
        }

        public bool PopShip(double timeScale)
        {
            if (nextShipTimes.Count == 0) return false;
            var ship = new Statistic.Ship(timeScale, 3);
            
            shipQueue.AddShip(ship, timeScale);

            nextShipTimes.RemoveAt(0);

            if (nextShipTimes.Count == 0)
                endTime = double.MaxValue;
            else
                endTime = nextShipTimes[0];

            return true;
        }

        public double EndTime => endTime;

        public int CompareTo(IQuest other) => endTime.CompareTo(other.EndTime);

        public bool TryMake(double timeScale) => PopShip(timeScale);
    }

    interface IQuest : IComparable<IQuest>
    {
        double EndTime { get; }
        bool TryMake(double timeScale);
    }
}