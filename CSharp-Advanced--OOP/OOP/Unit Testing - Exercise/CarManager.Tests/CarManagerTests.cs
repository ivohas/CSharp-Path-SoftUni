namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        //[TestCase(103454823623)]
        //[TestCase(103434423725)]
        //[Test]

        [TestCase("BMW", "M5", 7.2, 40)]
        [TestCase("BMW", "M3", 6.7, 35)]
        public void Car_Ctor(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car bmw = new Car(make, model, fuelConsumption, fuelCapacity);

            bool ctorWorksJustFine = true;
            if (bmw.Make != make)
            {
                ctorWorksJustFine = false;
            }
            if (bmw.Model != model)
            {
                ctorWorksJustFine = false;
            }
            if (bmw.FuelConsumption != fuelConsumption)
            {
                ctorWorksJustFine = false;
            }
            if (bmw.FuelCapacity != fuelCapacity)
            {
                ctorWorksJustFine = false;
            }
            Assert.IsTrue(ctorWorksJustFine);
        }

        [TestCase("BMW", "M5", 7.2, 40)]
        [TestCase("BMW", "M3", 6.7, 35)]
        [TestCase(null, "M5", 7.2, 40)]
        [TestCase("BMW", null, 6.7, 35)]
        [TestCase("BMW", "M5", 0, 40)]
        [TestCase("BMW", "M3", 6.7, 0)]
        [TestCase("BMW", "M5", -1, 40)]
        [TestCase("BMW", "M3", 6.7, -2)]
        public void Car_Prop(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            bool haveToThrowArgumentException = false;
            if (make == null || model == null || fuelConsumption <= 0|| fuelCapacity <= 0)
            {
                haveToThrowArgumentException = true;
            }

            if (haveToThrowArgumentException)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Car bmw = new Car(make, model, fuelConsumption, fuelCapacity);
                },
                "Argument Exception");
            }
        }

        [TestCase("BMW", "M5", 7.2, 40, 12.4, 600.23)]
        [TestCase("BMW", "M3", 6.7, 35, 12.1, 400.2)]
        [TestCase("BMW", "M5", 8.2, 42, 0.0, 50.12)]
        [TestCase("BMW", "M3", 6.9, 38, 15.3, 124.94)]
        [TestCase("BMW", "M3", 6.9, 38, 0.0, 643.08)]
        [TestCase("BMW", "M3", 6.9, 38, 39.0, 342.97)]
        [TestCase("BMW", "M3", 6.9, 38, 38.0, 200.74)]
        public void Car_RefuelTest(string make, string model, double fuelConsumption, double fuelCapacity, double refuelAmount, double distance)
        {
            Car bmw = new Car(make, model, fuelConsumption, fuelCapacity);

            if (refuelAmount <= 0)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    bmw.Refuel(refuelAmount);
                },
                "Fuel amount cannot be zero or negative!");
            }
            else if (refuelAmount >= bmw.FuelCapacity)
            {
                bmw.Refuel(refuelAmount);
                Assert.That(bmw.FuelAmount == fuelCapacity);
            }

            double fuelNeeded = (distance / 100) * bmw.FuelConsumption;

            if (fuelNeeded > bmw.FuelAmount)
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    bmw.Drive(distance);
                },
                "You don't have enough fuel to drive!");
            }
        }
    }
}