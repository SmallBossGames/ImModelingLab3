using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class KEK
    {
        public enum ShipType { First, Second, Third, Four }

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
            switch(shipType)
            {
                case ShipType.First:
                    return plusminus * 2 + 18;
                case ShipType.Second:
                    return plusminus * 3 + 24;
                case ShipType.Third:
                    return plusminus * 4 + 35;
                case ShipType.Four:
                    return plusminus * 3 + 21;
                default:
                    return 0.0;
            }
        }

        //Для пяти кораблей
        public static double GetShipRespawnTime() => R * 24.0 + 240;
    }
}