using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, 50.5);
            Motorcycle motorcycle = new Motorcycle(60, 10.5);
            RaceMotorcycle racemotorcycle = new RaceMotorcycle(140, 21.5);
            CrossMotorcycle crossmotorcycle = new CrossMotorcycle(110, 13.5);
            Car car = new Car(100, 50.5);
            FamilyCar familycar = new FamilyCar(99, 60.5);
            SportCar sportcar = new SportCar(190, 100.5);

            Console.WriteLine(vehicle.FuelConsumption);
            Console.WriteLine(motorcycle.FuelConsumption);
            Console.WriteLine(racemotorcycle.FuelConsumption);
            Console.WriteLine(crossmotorcycle.FuelConsumption);
            Console.WriteLine(car.FuelConsumption);
            Console.WriteLine(familycar.FuelConsumption);
            Console.WriteLine(sportcar.FuelConsumption);
        }
    }
}