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
            KEK.count1 = KEK.count2 = KEK.count3 = KEK.count4 = 0;
            var simulation2 = new Simulation2();
            WriteData(simulation2.Simulate);
        }

        private void fiveShipsButton_Click(object sender, EventArgs e)
        {
            KEK.count1 = KEK.count2 = KEK.count3 = KEK.count4 = 0;
            var simulation2 = new Simulation2();
            WriteData(simulation2.SimulateWihFifeShips);
        }

        void WriteData(GetStat getStat)
        {
            const int itCount = 50;

            double kvantil = Convert.ToDouble(kvantilTextBox.Text);
            double accuracy = Convert.ToDouble(accuracyTextBox.Text) / 100;
            double dispercion = 0;

            double[] times = new double[itCount];

            double itCountFinal = 0;

            double time = 0.0;
            int shipsCount = 0;
            var simulationTime = Convert.ToDouble(timeTextBox.Text);

            for (var i = 0; i < itCount; i++) // расчёт числа реализаций
            {
                var statistic = getStat(simulationTime);
                //var thisMathTime = statistic.MiddleFullTime;
                var thisMathTime = statistic.GetFullMiddleShipTime(Convert.ToInt32(ShipTypeTextBox.Text)) / statistic.GetShipCount(Convert.ToInt32(ShipTypeTextBox.Text));
                //Добавляем в список
                times[i] = thisMathTime;
                //Считаем матожидание
                time += thisMathTime / itCount;
                //time += statistic.GetFullMiddleShipTime(Convert.ToInt32(ShipTypeTextBox.Text)) / statistic.GetShipCount(Convert.ToInt32(ShipTypeTextBox.Text));
            }

            for (int i = 0; i < itCount; i++)
            {
                dispercion += (times[i] * times[i] - time * time);
            }

            dispercion /= itCount - 1;

            itCountFinal = Math.Ceiling(dispercion * dispercion * kvantil * kvantil / (accuracy * accuracy));

            KEK.count1 = KEK.count2 = KEK.count3 = KEK.count4 = 0;

            time = 0;
            shipsCount = 0;
            double queueTime = 0;

            for (var i = 0; i < itCountFinal; i++)
            {
                var statistic = getStat(simulationTime);
                var thisMathTime = statistic.MiddleFullTime;
                time += thisMathTime / itCountFinal;
                shipsCount += statistic.Count;
                queueTime += statistic.GetWaitingMiddleShipTime(Convert.ToInt32(ShipTypeTextBox.Text)) / shipsCount;
            }

            shipsCount /= (int)itCountFinal;

            ShipTimeTextBox.Text = Math.Round(time, 2).ToString();
            shipsTextBox.Text = shipsCount.ToString();
            ITTextBox.Text = itCountFinal.ToString();
            textBox1.Text = Math.Round((KEK.count1 / itCountFinal)).ToString();
            textBox2.Text = Math.Round((KEK.count2 / itCountFinal)).ToString();
            textBox3.Text = Math.Round((KEK.count3 / itCountFinal)).ToString();
            textBox4.Text = Math.Round((KEK.count4 / itCountFinal)).ToString();
            QueveTextBox.Text = Math.Round(queueTime, 2).ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}