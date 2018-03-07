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
            var statistic = new Statistic();
            shipQueue.Init(toWork);
            toWork.Init(shipQueue, storm, statistic);
            IQuest[] quests = new IQuest[3];
            quests[0] = shipQueue; quests[1] = storm; quests[2] = toWork;

            while(timeScale<fullTime)
            {
                Array.Sort(quests);
                for(int i = 0; i<quests.Length; i++)
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
            var statistic = new Statistic();
            shipQueue.Init(toWork);
            toWork.Init(shipQueue, storm, statistic);
            IQuest[] quests = new IQuest[3];
            quests[0] = shipQueue; quests[1] = storm; quests[2] = toWork;

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
        int count=0;

        double fullTime = 0.0;

        public int Count => count;

        public double FullTime => fullTime;

        public void IncCounter() => count++;

        public void AddFullTime(double time) => fullTime += time;

        public class Ship: IComparable<Ship>
        {
            double createTime;
            double inDockTime;
            public double endingTime;
            bool isSpecial;
            public Ship(double createTime, double inDockTime, bool isSpecial=false, double endingTime=0.0)
            {
                this.createTime = createTime;
                this.inDockTime = inDockTime;
                this.isSpecial = isSpecial;
                this.endingTime = endingTime;
            }

            public double CreateTime => createTime;
            public double InDockTime => inDockTime;
            public bool IsSpecial => isSpecial;

            public int CompareTo(Ship other)
            {
                return endingTime.CompareTo(other.endingTime);
            }
        }
    }

    class ShipQueue : IQuest
    {
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
            endTime = 17.0;
            shipQueue = new Queue<Statistic.Ship>();
        }

        public void AddShip(Statistic.Ship ship, double timeScale)
        {
            shipQueue.Enqueue(ship);
            toWork.PushShip(timeScale);
        }

        public bool TryMake(double timeScale)
        {
            endTime = timeScale + 17.0;
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

        public void Init(ShipQueue shipQueue, Storm storm, Statistic statistic)
        {
            this.shipQueue = shipQueue;
            this.storm = storm;
            this.statistic = statistic;
        }

        private SortedSet<Statistic.Ship> dock = new SortedSet<Statistic.Ship>();

        public bool PushShip(double timeScale)
        {
            if (storm.IsStorm) return false;
            if (shipQueue.ThisQueue.Count != 0 && dock.Count < 3)
            {
                var pool = shipQueue.ThisQueue.Dequeue();
                pool.endingTime = timeScale + pool.InDockTime;
                dock.Add(pool);

                if (dock.Count != 0)
                    endTime = dock.Min.endingTime;
                else
                    endTime = -1.0;
                return true;
            }
            return false;
        }

        public bool PopShip(double timeScale)
        {
            if (storm.IsStorm) return false;
            if (dock.Count == 0) return false;
            statistic.IncCounter();
            statistic.AddFullTime(timeScale - dock.Min.CreateTime);
            dock.Remove(dock.Min);
            if (dock.Count != 0)
                endTime = dock.Min.endingTime;
            else
                endTime = -1.0;
            PushShip(timeScale);
            return false;
        }

        public int CompareTo(IQuest other) => EndTime.CompareTo(other.EndTime);

        public bool TryMake(double timeScale) => PopShip(timeScale);
    }

    class FifeShips:IQuest
    {
        const int shipCount = 5;
        double endTime = 0.0;

        ShipQueue shipQueue;
        
        SortedSet<double> nextShipTimes = new SortedSet<double>();

        public FifeShips()
        {
            for (int i = 0; i < shipCount; i++)
                nextShipTimes.Add(0.0);
        }

        public void Init(ShipQueue shipQueue)
        {
            this.shipQueue = shipQueue;
        }
       
        public bool PushShip(double timeScale)
        {
            if (nextShipTimes.Count < shipCount) return false;

            nextShipTimes.Add(timeScale + KEK.GetShipRespawnTime());
            endTime = nextShipTimes.Min;
            return true;
        }

        public bool PopShip(double timeScale)
        {
            if (nextShipTimes.Count == 0) return false;
            var ship = new Statistic.Ship(timeScale, KEK.GetLoadTime(KEK.ShipType.Four), true);
            shipQueue.AddShip(ship, timeScale);

            nextShipTimes.Remove(nextShipTimes.Min);

            if (nextShipTimes.Count == 0)
                endTime = double.MaxValue;
            else
                endTime = nextShipTimes.Min;

            return true;
        }
    
        public double EndTime => endTime;

        public int CompareTo(IQuest other) => endTime.CompareTo(other.EndTime);

        public bool TryMake(double timeScale) => PopShip(timeScale);
    }

    interface IQuest:IComparable<IQuest>
    {
        double EndTime { get; }
        bool TryMake(double timeScale);
    }
}
