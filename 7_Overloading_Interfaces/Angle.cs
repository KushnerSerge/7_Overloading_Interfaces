using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Overloading_Interfaces
{
    public class Angle
    {
        public int Degree { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Car[] arr = new Car[6];

        public Angle(int degree, int minutes, int seconds)
        {
            Degree = degree;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Angle() { }

        public static Angle operator +(Angle angle1, Angle angle2)
        {
            int sumSeconds = angle1.Seconds + angle2.Seconds;
            int sumMinutes = angle1.Minutes + angle2.Minutes;
            int SumDegree = angle1.Degree + angle2.Degree;

            int TotalSeconds = sumSeconds % 60;
            int TotalMinutes = (sumMinutes + (sumSeconds / 60)) % 60;
            int TotalDegree = SumDegree + (sumMinutes / 60);

            return new Angle
            {
                Seconds = TotalSeconds,
                Minutes = TotalMinutes,
                Degree = TotalDegree
            };
        }

        public static Angle operator -(Angle angle1, Angle angle2)
        {
            int DifSeconds = angle1.Seconds - angle2.Seconds;
            int DifMinutes = angle1.Minutes - angle2.Minutes;
            int DifDegree = angle1.Degree - angle2.Degree;

            if (DifSeconds < 0)
            {

                DifSeconds = DifSeconds + 60;
                DifMinutes = DifMinutes - 1;
            }

            if (DifMinutes < 0)
            {
                DifMinutes = DifMinutes + 60;
                DifDegree = DifDegree - 1;
            }

            return new Angle
            {
                Seconds = DifSeconds,
                Minutes = DifMinutes,
                Degree = DifDegree
            };
        }

        public static Angle operator *(Angle angle1, Angle angle2)
        {
            int MultSeconds = angle1.Seconds * angle2.Seconds;
            int MultMinutes = angle1.Minutes * angle2.Minutes;
            int MultDegree = angle1.Degree * angle2.Degree;

            int TotalSeconds = MultSeconds % 60;
            int TotalMinutes = (MultMinutes + (MultSeconds / 60)) % 60;
            int TotalDegree = MultDegree + (MultMinutes / 60);

            return new Angle
            {
                Seconds = TotalSeconds,
                Minutes = TotalMinutes,
                Degree = TotalDegree
            };
        }

        public static Angle operator *(Angle angle, int value)
        {
            int MultSeconds = angle.Seconds * value;
            int MultMinutes = angle.Minutes * value;
            int MultDegree = angle.Degree * value;

            int TotalSeconds = MultSeconds % 60;
            int TotalMinutes = (MultMinutes + (MultSeconds / 60)) % 60;
            int TotalDegree = MultDegree + (MultMinutes / 60);

            return new Angle
            {
                Seconds = TotalSeconds,
                Minutes = TotalMinutes,
                Degree = TotalDegree
            };
        }

        public static bool operator ==(Angle angle1, Angle angle2)
        {
            if (angle1.Seconds == angle2.Seconds && angle1.Minutes == angle2.Minutes && angle1.Degree == angle2.Degree)
                return true;
            else return false;
        }
        public static bool operator !=(Angle angle1, Angle angle2)
        {
            return !(angle1 == angle2);
        }

        public Car this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }



    }
}
