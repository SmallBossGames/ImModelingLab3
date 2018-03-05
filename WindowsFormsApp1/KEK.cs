using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class KEK
    {
        public enum ShipType { First, Second, Third }

        public struct Storm
        {
            public double time, interval;

            public Storm(double time, double interval)
            {
                this.time = time;
                this.interval = interval;
            }
        }

        public static double QStorm(double math) // генерация события шторма
        {
            Random r;
            double random;

            r = new Random();
            random = r.NextDouble();

            return -math * Math.Log(random);
        }

        public static double GetStorm()
        {
            double plusminus;
            Random r;

            r = new Random();

            plusminus = r.NextDouble();

            return plusminus * 2 + 4;
        }


        public static double GenShips() // генерация корабля происходит каждые 17 часов
        {
            var random = new Random();
            var r = random.NextDouble();

            if (r <= 0.55) return GetLoadTime(ShipType.First);
            if (r > 0.55 & r <= 0.75) return GetLoadTime(ShipType.Second);
            else return GetLoadTime(ShipType.Third);
        }

        public static double GetLoadTime(ShipType shipType)
        {
            double plusminus;
            var r = new Random();

            plusminus = r.NextDouble();

            if (shipType == ShipType.First) return plusminus * 2 + 18;
            if (shipType == ShipType.Second) return plusminus * 3 + 24;
            else return plusminus * 4 + 35;
        }
    }
}