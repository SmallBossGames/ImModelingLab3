using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class KEK
    {
        //public enum ShipType { First, Second, Third, Four }

        static Random random = new Random();

        public static int count1 = 0;
        public static int count2 = 0;
        public static int count3 = 0;
        public static int count4 = 0;

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

        public static byte GenShips() // генерация корабля происходит каждые 17 часов
        {
            var r = R;

            if (r <= 0.25)
                return 0;
            else if (r > 0.25 & r <= 0.8)
                return 1;
            else
                return 2;
        }

        public static double GetLoadTime(byte typeNumber)
        {
            var plusminus = R;

            switch (typeNumber)
            {
                case 0:
                    count1++;
                    return plusminus * 4 + 16;
                case 1:
                    count2++;
                    return plusminus * 6 + 21;
                case 2:
                    count3++;
                    return plusminus * 8 + 31;
                case 3:
                    count4++;
                    return plusminus * 6 + 18;
                default:
                    throw new Exception("Wrong number");
            }
        }

        //Для пяти кораблей
        public static double GetShipRespawnTime() => (R * 48.0) - 24.0 + 240;
    }
}