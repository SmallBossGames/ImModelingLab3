﻿using System;
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
            double kvantil = Convert.ToDouble(kvantilTextBox.Text);
            double accuracy = Convert.ToDouble(accuracyTextBox.Text) / 100;

            double dispercion1 = 0;
            double dispersion2 = 0;
            double dispersion3 = 0;
            double dispersion4 = 0;

            const int itCount = 50;
            double itCountFinal = 0;
            double[] arrayOfTime = new double[itCount];

            double time = 0.0;
            int shipsCount = 0;
            var simulationTime = Convert.ToDouble(timeTextBox.Text);

            for (var i = 0; i < itCount; i++) // симуляция для расчёта числа симуляций
            {
                var statistic = getStat(simulationTime);
                time += statistic.FullTime / (statistic.Count * itCount);
                shipsCount += statistic.Count;
                arrayOfTime[i] = statistic.Count;
            }

            shipsCount /= itCount;

            ShipTimeTextBox.Text = Math.Round(time, 1).ToString();
            shipsTextBox.Text = shipsCount.ToString();
            ITTextBox.Text = itCountFinal.ToString();
            textBox1.Text = (KEK.count1 / itCount).ToString();
            textBox2.Text = (KEK.count2 / itCount).ToString();
            textBox3.Text = (KEK.count3 / itCount).ToString();
            textBox4.Text = (KEK.count4 / itCount).ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}