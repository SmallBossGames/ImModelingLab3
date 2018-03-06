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
            shipQueue.toWork = toWork;
            toWork.shipQueue = shipQueue;
            toWork.storm = storm;
            toWork.statistic = statistic;
            IQuest[] quests = new IQuest[3];
            quests[0] = shipQueue; quests[1] = storm; quests[2] = toWork;

            while(timeScale<fullTime)
            {
                Array.Sort(quests);
                for(int i = 0; i<quests.Length; i++)
                {
                    if (quests[i].GetTime > timeScale)
                        timeScale = quests[i].GetTime;
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
            public double endingTime=0.0;
            bool isSpecial;
            public Ship(double createTime, double inDockTime, bool isSpecial=false)
            {
                this.createTime = createTime;
                this.inDockTime = inDockTime;
                this.isSpecial = isSpecial;
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
        public double GetTime => endTime;

        public ShipQueue()
        {
            endTime = 17.0;
            shipQueue = new Queue<Statistic.Ship>();
        }

        public bool TryMake(double timeScale)
        {
            endTime = timeScale + 17.0;
            shipQueue.Enqueue(new Statistic.Ship(timeScale, KEK.GenShips()));
            toWork.PushShip(timeScale);
            return true;
        }

        public int CompareTo(IQuest other)
        {
            return GetTime.CompareTo(other.GetTime);
        }
    }

    class Storm : IQuest
    {
        const double stormMath = 48.0;

        private double endTime;
        bool isStorm;

        public double GetTime => endTime;

        public bool IsStorm => isStorm;

        public Storm()
        {
            isStorm = false; 
        }

        public int CompareTo(IQuest other)
        {
            return GetTime.CompareTo(other.GetTime);
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
        public double GetTime => endTime;

        public ShipQueue shipQueue;
        public Storm storm;
        public Statistic statistic;

        private List<Statistic.Ship> dock = new List<Statistic.Ship>(3);

        public bool PushShip(double timeScale)
        {
            if (storm.IsStorm) return false;
            if (shipQueue.ThisQueue.Count != 0 && dock.Count < 3)
            {
                var pool = shipQueue.ThisQueue.Dequeue();
                pool.endingTime = timeScale + pool.InDockTime;
                dock.Add(pool);
                dock.Sort();

                if (dock.Count != 0)
                    endTime = dock[0].endingTime;
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
            statistic.AddFullTime(timeScale - dock[0].CreateTime);
            dock.RemoveAt(0);
            if (dock.Count != 0)
                endTime = dock[0].endingTime;
            else
                endTime = -1.0;
            PushShip(timeScale);
            return false;
        }

        public int CompareTo(IQuest other)
        {
            return GetTime.CompareTo(other.GetTime);
        }

        public bool TryMake(double timeScale)
        {
            return PopShip(timeScale);
        }
    }

    interface IQuest:IComparable<IQuest>
    {
        double GetTime { get; }
        bool TryMake(double timeScale);
    }
}
