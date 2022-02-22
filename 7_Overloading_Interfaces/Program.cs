// See https://aka.ms/new-console-template for more information
using _7_Overloading_Interfaces;

Console.WriteLine("Hello, World!");

Angle angle1 = new Angle(3, 36, 53);
Angle angle2 = new Angle(4, 27, 45);

Car[] carsArray = new Car[] { new Car(1, 180, "Lexus LX450"), new Car(2, 180, "Toyota Prado"), new Car(3, 200, "LR Defender"),
                               new Car(4,220,"BMW X5"), new Car(5, 210, "Mazda CX-5"), new Car(6, 250, "Subaru Forester")     };


Console.WriteLine("Adding 2 Angular Objects");
Angle angle3 = angle1 + angle2;
Console.WriteLine("Degree:{0}, Minutes:{1}, Seconds:{2}", angle3.Degree, angle3.Minutes, angle3.Seconds);

Console.WriteLine("Subtract 2 Angular Objects");
Angle angle4 = angle2 - angle1;
Console.WriteLine("Degree:{0}, Minutes:{1}, Seconds:{2}", angle4.Degree, angle4.Minutes, angle4.Seconds);

Console.WriteLine("Multiply 2 Angular Objects");
Angle angle5 = angle2 * angle1;
Console.WriteLine("Degree:{0}, Minutes:{1}, Seconds:{2}", angle5.Degree, angle5.Minutes, angle5.Seconds);

Console.WriteLine("Checking equality of 2 Angular Objects");
bool equal = angle2 == angle1;
Console.WriteLine("Objects are equal:{0}", equal);

Angle angular6 = new Angle(1, 1, 1);

for (int i = 0; i < angular6.arr.Length; i++)
{
    angular6[i] = carsArray[i];
}

// Using operator overloading to get cars
Console.WriteLine("---------------");
for (int i = 0; i < angular6.arr.Length; i++)
{
    Console.WriteLine("----{0} ", angular6[i]);
}
Console.WriteLine("---------------");

// Testing IEnumerable,IEnumerator functionality for Cars
//Car[] carsArray = new Car[] { new Car(1, 180, "Lexus LX450"), new Car(2, 180, "Toyota Prado"), new Car(3, 200, "LR Defender"),
//                               new Car(4,220,"BMW X5"), new Car(5, 210, "Mazda CX-5"), new Car(6, 250, "Subaru Forester")     };

Cars obiectCars = new Cars(carsArray);
foreach (Car car in obiectCars)
{
    Console.WriteLine("CarName: {0}, CarSpeed: {1}", car.Marka, car.Speed);
}

Console.WriteLine("-----------------   ----   ------");
// Testing Clone for a Car object
Car objectCar = new Car(7, 230, "Lexus LX 450");
Car objectCarClone = (Car)objectCar.Clone(); 
Console.WriteLine("clone  for lexus is: {0} ", objectCarClone);


Console.WriteLine("-----------------   ----   ------");
Console.WriteLine("Checking the IComparable functionality of sorting an array of cars");
Car[] carsArray12 = new Car[] { new Car(2, 180, "Lexus LX450"), new Car(6, 180, "Toyota Prado"), new Car(3, 200, "LR Defender"),
                               new Car(1,220,"BMW X5"), new Car(5, 210, "Mazda CX-5"), new Car(4, 250, "Subaru Forester")     };

Array.Sort(carsArray12);
foreach(Car car in carsArray12)
{
    Console.WriteLine(car);
}

Console.WriteLine("------------- - - ------------ -- - -");
Console.WriteLine("Checking the IComparer functionality for sorting by speed of car");
Array.Sort(carsArray12, Car.SortBySpeed);

foreach (Car car in carsArray12)
{
    Console.WriteLine(car);
}