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

        static Random random = new Random();
        static double R => random.NextDouble();

        public static double QStorm(double math) // генерация события шторма
        {
            return -math * Math.Log(R);
        }

        public static double GetStorm()
        {
            double plusminus;

            plusminus = R;

            return plusminus * 2 + 4;
        }


        public static double GenShips() // генерация корабля происходит каждые 17 часов
        {
            var r = R;
            if (r <= 0.55) return GetLoadTime(ShipType.First);
            if (r > 0.55 & r <= 0.75) return GetLoadTime(ShipType.Second);
            else return GetLoadTime(ShipType.Third);
        }

        public static double GetLoadTime(ShipType shipType)
        {

            var plusminus = R;

            if (shipType == ShipType.First) return plusminus * 2 + 18;
            if (shipType == ShipType.Second) return plusminus * 3 + 24;
            else return plusminus * 4 + 35;
        }
    }
}