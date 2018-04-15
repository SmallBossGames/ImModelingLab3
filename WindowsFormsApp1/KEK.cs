using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class KEK
    {
        public enum ShipType { First, Second, Third, Four }

        static Random random = new Random();

        public static int count1 = 0;
        public static int count2 = 0;
        public static int count3 = 0;
        public static int count4 = 0;

        public static double[] array1 = new double[100];
        public static double[] array2 = new double[100];
        public static double[] array3 = new double[100];
        public static double[] array4 = new double[100];

        static int i = 0;
        static int j = 0;
        static int o = 0;
        static int p = 0;

        static double R => (double)random.Next(int.MaxValue) / int.MaxValue;

        public static double QStorm(double math) // генерация события шторма
        {
            return -math * Math.Log(R);
        }

        public static double GetStorm()
        {
            double plusminus;

            plusminus = R;

            return plusminus * 4 + 2;
        }

        public static double GenShips() // генерация корабля происходит каждые 17 часов
        {
            var r = R;
            if (r <= 0.25) return GetLoadTime(ShipType.First);
            if (r > 0.25 & r <= 0.8) return GetLoadTime(ShipType.Second);
            else return GetLoadTime(ShipType.Third);
        }

        public static double GetLoadTime(ShipType shipType)
        {
            var plusminus = R;

            switch (shipType)
            {
                case ShipType.First:
                    count1++; array1[i] = plusminus * 4 + 16; i++;
                    return plusminus * 4 + 16;
                case ShipType.Second:
                    count2++; array2[j] = plusminus * 6 + 21; j++;
                    return plusminus * 6 + 21;
                case ShipType.Third:
                    count3++; array3[o] = plusminus * 8 + 31; o++;
                    return plusminus * 8 + 31;
                case ShipType.Four:
                    count4++; array4[p] = plusminus * 6 + 18; p++;
                    return plusminus * 6 + 18;
                default:
                    return 0.0;
            }
        }

        //Для пяти кораблей
        public static double GetShipRespawnTime() => (R * 48.0) - 24.0 + 240;
    }
}