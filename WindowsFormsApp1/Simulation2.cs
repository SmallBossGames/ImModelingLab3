using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Simulation2
    {

        int Simulate()
        {
            var shipQueue = new ShipQueue();
            var storm = new Storm();
            var toWork = new ToWork();
            IQuest[] quests = new IQuest[3];
            quests[0] = shipQueue; quests[1] = storm; quests[2] = toWork;


            return 0;
        }
    }

    class ShipQueue : IQuest
    {
        private double endTime;
        Queue<double> shipQueue;

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
        public double GetTime => throw new NotImplementedException();

        public int CompareTo(IQuest other)
        {
            throw new NotImplementedException();
        }

        public bool TryMake(double timeScale)
        {
            throw new NotImplementedException();
        }
    }

    interface IQuest:IComparable<IQuest>
    {
        double GetTime { get; }
        bool TryMake(double timeScale);
    }
}
