using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Simulation.SimulationDefault simulation;
            int count = 0;
            for(int i = 0; i < 10000; i++)
            {
                simulation = new Simulation.SimulationDefault();
                count += simulation.Simulation(8640);
            }
            double hui = (float)count / 10000.0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
