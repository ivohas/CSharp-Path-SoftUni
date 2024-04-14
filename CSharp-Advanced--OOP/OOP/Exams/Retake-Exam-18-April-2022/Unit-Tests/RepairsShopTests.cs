using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [Test]
            public void TestCarCtor()
            {
                Car mercedes = new Car("Mercedes", 2);
                Car bmw = new Car("BMW", 0);
                Car cadilac = new Car("Cadilac", 1);

                Assert.That(mercedes.CarModel == "Mercedes"
                    && mercedes.NumberOfIssues == 2
                    && mercedes.IsFixed == false);

                Assert.That(bmw.CarModel == "BMW"
                    && bmw.NumberOfIssues == 0
                    && bmw.IsFixed == true);

                Assert.That(cadilac.CarModel == "Cadilac"
                    && cadilac.NumberOfIssues == 1
                    && cadilac.IsFixed == false);
            }

            [Test]
            public void TestGarageCtor()
            {
                List<Car> cars = new List<Car>()
                {
                    new Car("BMW", 0),
                    new Car("Mercedes", 2),
                    new Car("Cadilac", 1),
                };

                Garage alduServiz = new Garage("AlduServiz", 5);
                Garage imantek = new Garage("Imantek", 2);
                Assert.That(
                    alduServiz.Name == "AlduServiz"
                    && alduServiz.MechanicsAvailable == 5
                    && imantek.Name == "Imantek"
                    && imantek.MechanicsAvailable == 2
                    );
            }
            [Test]
            public void TestValidators()
            {               
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage alduServiz = new Garage(null, 5);
                }, "Invalid garage name.");

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage bashMiEDrago = new Garage("", 5);
                }, "Invalid garage name.");

                Assert.Throws<ArgumentException>(() =>
                {
                    Garage imantek = new Garage("Imantek", 0);
                }, "At least one mechanic must work in the garage.");

                Assert.Throws<ArgumentException>(() =>
                {
                    Garage qnko = new Garage("Qnko", -1);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void Test_AddCar()
            {
                Garage garage = new Garage("Imaniedo", 2);

                Car mercedes = new Car("Mercedes", 10);
                Car bmw = new Car("BMW", 10);
                Car cadilac = new Car("Cadilac", 1);

                garage.AddCar(mercedes);
                garage.AddCar(bmw);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(bmw);
                }, "No mechanic available.");
            }

            [Test]
            public void Test_FixCar()
            {
                Garage garage = new Garage("Imaniedo", 2);

                Car mercedes = new Car("Mercedes", 10);
                Car bmw = new Car("BMW", 10);
                Car cadilac = new Car("Cadilac", 1);


                garage.AddCar(mercedes);
                garage.AddCar(bmw);

                garage.FixCar(mercedes.CarModel);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("naQnkoKolata");
                }, $"The car naQnkoKolata doesn't exist.");
                
                Car fixedCar = garage.FixCar(bmw.CarModel);
                Assert.That(fixedCar.IsFixed == true);
            }

            [Test]
            public void Test_RemoveFixedCar()
            {
                Garage garage = new Garage("Imaniedo", 2);

                Car mercedes = new Car("Mercedes", 10);
                Car bmw = new Car("BMW", 10);
                Car cadilac = new Car("Cadilac", 1);


                garage.AddCar(mercedes);
                garage.AddCar(bmw);

                int a = 0;
                Assert.Throws<InvalidOperationException>(() =>
                {
                   a = garage.RemoveFixedCar();
                }, $"No fixed cars available.");

                bmw = garage.FixCar(bmw.CarModel);
                a = garage.RemoveFixedCar();
                Assert.That(a == 1);
            }

            [Test]
            public void Test_Report()
            {
                Garage garage = new Garage("Imaniedo", 5);

                Car mercedes = new Car("Mercedes", 10);
                Car bmw = new Car("BMW", 10);
                Car cadilac = new Car("Cadilac", 1);


                garage.AddCar(mercedes);
                garage.AddCar(bmw);
                garage.AddCar(cadilac);

                bmw = garage.FixCar(bmw.CarModel);

                string report = garage.Report();

                Assert.That(report == $"There are {2} which are not fixed: {mercedes.CarModel}, {cadilac.CarModel}.");
            }
        }
    }
}