using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void InvalidNameStringIsEmpty()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(String.Empty, 5);

                }, "Invalid garage name.");
            }
            [Test]
            public void InvalidNameIsNull()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(null, 5);

                }, "Invalid garage name.");
            }
            [Test]
            public void NameIsOk()
            {
                const string name = "BlueMech";
                var garage = new Garage(name, 5);
                Assert.That(garage.Name, Is.EqualTo(name));
            }
            [Test]
            public void AvelableMechAreBelowZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("BlueMech", -132);


                }, "At least one mechanic must work in the garage.");
            }
            [Test]
            public void AvelableMechAreZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("BlueMech", 0);


                }, "At least one mechanic must work in the garage.");
            }
            [Test]
            public void AvelableMechAreAboveZero()
            {
                const int avelable = 12;
                Garage garage = new Garage("BlueMech", 12);
                Assert.That(avelable, Is.EqualTo(garage.MechanicsAvailable));
            }
            [Test]
            public void InvalidAddNoMechAvelable()
            {
                Garage garage = new Garage("BlueMech", 1);
                Car Ferrari = new Car("Stradale", 1);
                Car Buggati = new Car("Chiron", 2);
                garage.AddCar(Ferrari);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(Buggati);

                }, "No mechanic available.");
            }
            [Test]
            public void SuccsesfullyAddedCar()
            {
                const int carsInGarage = 2;

                Garage garage = new Garage("BlueMech", 4);
                Car Ferrari = new Car("Stradale", 1);
                Car Buggati = new Car("Chiron", 2);
                garage.AddCar(Ferrari);
                garage.AddCar(Buggati);
                Assert.That(carsInGarage, Is.EqualTo(garage.CarsInGarage));
            }
            [Test]
            public void InvalidFixCarIsNotInGarage()
            {
                const string carToRepair = "Aston Martin";
                Garage garage = new Garage("BlueMech", 4);
                Car Ferrari = new Car("Stradale", 1);
                Car Buggati = new Car("Chiron", 2);
                garage.AddCar(Ferrari);
                garage.AddCar(Buggati);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(carToRepair);
                }, $"The car {carToRepair} doesn't exist.");
            }
            [Test]
            public void TheCarIsFixed()
            {
                const string carToRepair = "Chiron";
                Garage garage = new Garage("BlueMech", 4);
                Car Ferrari = new Car("Stradale", 1);
                Car Bugatti = new Car("Chiron", 2);
                garage.AddCar(Ferrari);
                garage.AddCar(Bugatti);
                garage.FixCar(carToRepair);
                Assert.AreEqual(Bugatti.NumberOfIssues, 0);

            }
            [Test]
            public void ProperlyRemovedFixedCars() {
                const string carToRepair = "Chiron";
                Garage garage = new Garage("BlueMech", 4);
                Car Ferrari = new Car("Stradale", 1);
                Car Bugatti = new Car("Chiron", 2);
                garage.AddCar(Ferrari);
                garage.AddCar(Bugatti);
                garage.FixCar(carToRepair);
                garage.RemoveFixedCar();
                Assert.That(garage.CarsInGarage, Is.EqualTo(1));

            }
            [Test]
            public void ProblemWithRemovingCars() {
                
                Garage garage = new Garage("BlueMech", 4);
                Car Ferrari = new Car("Stradale", 1);
                Car Bugatti = new Car("Chiron", 2);
                garage.AddCar(Ferrari);
                garage.AddCar(Bugatti);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();

                }, "No fixed cars available.");
            }
            [Test]
            public void ReportCheck() {
                const string carToRepair = "Chiron";
                Garage garage = new Garage("BlueMech", 4);
                Car Ferrari = new Car("Stradale", 1);
                Car Bugatti = new Car("Chiron", 2);
                Car AstonMartin = new Car("Vulcan", 1);
                garage.AddCar(Ferrari);
                garage.AddCar(Bugatti);
                garage.AddCar(AstonMartin);
                garage.FixCar(carToRepair);
                
                string report = "There are 2 which are not fixed: Vulcan, Stradale.";
                string report1 = garage.Report();
            }
        }
    }
}