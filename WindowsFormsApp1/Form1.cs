using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        delegate Statistic GetStat(double time);
        public Form1()
        {
            InitializeComponent();
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            var simulation2 = new Simulation2();
            WriteData(simulation2.Simulate);
        }

        private void fiveShipsButton_Click(object sender, EventArgs e)
        {
            var simulation2 = new Simulation2();
            WriteData(simulation2.SimulateWihFifeShips);
        }
        
        void WriteData(GetStat getStat)
        {
            const int itCount = 500;
            double time = 0.0;
            double shipsCount = 0;
            var simulationTime = Convert.ToDouble(timeTextBox.Text);
            for (var i = 0; i < itCount; i++)
            {
                var simulation2 = new Simulation2();
                var statistic = getStat(simulationTime);
                time += statistic.FullTime / (statistic.Count * itCount);
                shipsCount += statistic.Count;
            }
            shipsCount /= itCount;
            ShipTimeTextBox.Text = Math.Round(time, 3).ToString();
            shipsTextBox.Text = (Math.Floor(shipsCount)).ToString();
        }
    }
}