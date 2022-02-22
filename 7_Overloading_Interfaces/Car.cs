using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Overloading_Interfaces
{
    public class Car : ICloneable, IComparable
    {
        public int ID { get; set; }
        public int Speed { get; set; }
        public string Marka { get; set; }

        public Car(int iD, int speed, string marka)
        {
            ID = iD;
            Speed = speed;
            Marka = marka;
        }

        public object Clone()
        {
            return (Car)this.MemberwiseClone();
        }
        public override string ToString()
        {
            return String.Format("ID: {0,3} Marka: {1,-7} Speed: {2,3}", ID, Marka, Speed);
        }

        // aici pot utiliza direct campul <Viteza> si la apelarea metododei < Array.Sort(myArray)>  va sorta dupa viteza
        public int CompareTo(object? obj)
        {
            Car temp = (Car)obj;
            if (this.ID > temp.ID)
                return 1;
            if (this.ID < temp.ID)
                return -1;
            else
                return 0;
        }
        // Aici utilizam IComparer pentru a sorta arrayul care contine obiecte de car sa fie sortat dupa conditia propusa
        public static IComparer SortBySpeed
        { get { return (IComparer)new SpeedCarComparer(); } }

    }

    public class Cars : IEnumerable
    {
        private Car[] _cars;
        public Cars(Car[] cArray)
        {
            _cars = new Car[cArray.Length];

            for (int i = 0; i < cArray.Length; i++)
            {
                _cars[i] = cArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private CarsEnum GetEnumerator()
        {
            return new CarsEnum(_cars);
        }
    }

    public class CarsEnum : IEnumerator
    {
        public Car[] _cars;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public CarsEnum(Car[] listOfCars)
        {
            _cars = listOfCars;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _cars.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Car Current
        {
            get
            {
                try
                {
                    return _cars[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
