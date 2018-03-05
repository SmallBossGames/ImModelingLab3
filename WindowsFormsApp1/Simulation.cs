using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Simulation
    {
        
        class Quest:IComparable<Quest>
        {
            public delegate bool Procedure(out double endTime, double timeScale);
            double endTime;
            Procedure procedure;

            public Quest(Procedure procedure, double endTime = 0.0)
            {
                this.procedure = procedure;
                this.endTime = endTime;
            }

            public bool TryMake(ref double timeScale)
            {
                if (timeScale < endTime)
                    timeScale = endTime;
                if (procedure(out var poolTime, timeScale))
                {
                    endTime = poolTime;
                    return true;
                }

                return false;
            }

            public int CompareTo(Quest other)
            {
                return endTime.CompareTo(other.endTime);
            }
        }

        public class SimulationDefault
        {
            protected double timeScale = 0.0;

            const double addQueueInterval = 17.0;
            const double stormMath = 48.0;

            Queue<double> shipsQueue;

            protected double[] dock = { -1.0, -1.0, -1.0 };
            protected bool isStorm = false;

            int count;

            public SimulationDefault()
            {
                shipsQueue = new Queue<double>();
            }

            public virtual int Simulation(double time)
            {
                Quest[] nextEventArr = { new Quest(AddQueue, addQueueInterval), new Quest(ToWork), new Quest(LetsStorm) };

                while (timeScale < time)
                {
                    Array.Sort(nextEventArr);
                    for (int i = 0; i< nextEventArr.Length; i++)
                    {
                        nextEventArr[i].TryMake(ref timeScale);
                    }
                }
                return count;
            }

            protected bool AddQueue(out double endTime, double timeScale)
            {
                endTime = timeScale + 17.0;
                shipsQueue.Enqueue(KEK.GenShips());
                return true;
            }

            protected virtual bool ToWork(out double endTime, double timeScale)
            {
                if(!isStorm)
                {
                    for (int i = 0; i < dock.Length; i++)
                    {
                        if (dock[i] > 0)
                        {
                            dock[i] = -1.0;
                            count++;
                            break;
                        }
                    }
                }

                if(shipsQueue.Count==0 || isStorm)
                {
                    endTime = timeScale;
                    return false;
                }

                dock[0] = timeScale + shipsQueue.Dequeue();
                Array.Sort(dock);
                endTime = dock[0];
                return true;
            }

            protected bool LetsStorm(out double endTime, double timeScale)
            {
                if (!isStorm)
                {
                    isStorm = true;
                    endTime = timeScale + KEK.QStorm(stormMath);
                }
                else
                {
                    isStorm = false;
                    endTime = timeScale + KEK.GetStorm();
                }
                return true;
            }
        }

        /*public class SimulationWithFifeShips: SimulationDefault
        {
            Queue<(bool isSpecial, double time)> shipQueue;

            SimulationWithFifeShips()
            {
                shipQueue = new Queue<(bool isSpecial, double time)>();
            }

            public override void Simulation(double time)
            {
                base.Simulation(time);
            }

            protected override bool ToWork(out double endTime, double timeScale)
            {
                return base.ToWork(out endTime, timeScale);
            }

            bool FifeShips(out double endTime)
            {
                throw new NotImplementedException();
            }
        }*/
    }
}
