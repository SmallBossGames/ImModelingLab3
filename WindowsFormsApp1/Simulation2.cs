using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Simulation2
    {

        public int Simulate(double fullTime)
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

            return statistic.Count;
        }
    }

    class Statistic
    {
        int count;

        public int Count => count;

        public void IncCounter() => count++;
    }

    class ShipQueue : IQuest
    {
        private double endTime;
        Queue<double> shipQueue;
        public ToWork toWork;

        public Queue<double> ThisQueue => shipQueue;
        public double GetTime => endTime;

        public ShipQueue()
        {
            endTime = 17.0;
            shipQueue = new Queue<double>();
        }

        public bool TryMake(double timeScale)
        {
            endTime = timeScale + 17.0;
            shipQueue.Enqueue(KEK.GenShips());
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

        private double[] dock = { -1.0, -1.0, -1.0};
        int dockCount = 0;

        public bool PushShip(double timeScale)
        {
            if (storm.IsStorm) return false;
            if (shipQueue.ThisQueue.Count != 0 && dock[0] < 0.0)
            {
                dock[0] = timeScale + shipQueue.ThisQueue.Dequeue();
                Array.Sort(dock);
                dockCount++;
                if (dockCount != 0)
                    endTime = dock[dockCount - 1];
                else
                    endTime = -1.0;
                return true;
            }
            return false;
        }

        public bool PopShip(double timeScale)
        {
            if (dockCount == 0) return false;
            statistic.IncCounter();
            dock[dockCount - 1] = -1.0;
            dockCount--;
            if (dockCount != 0)
                endTime = dock[dockCount - 1];
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
