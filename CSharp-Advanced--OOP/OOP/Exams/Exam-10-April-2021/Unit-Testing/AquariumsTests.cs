namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [TestCase("Gosho")]
        [TestCase("Ilcho")]
        public void Test_CtorFish(string name)
        {
            Fish fish = new Fish(name);
            Assert.That(fish.Name == name);
        }

        [TestCase("Akvalandia", 10)]
        [TestCase("Borovo", 15)]
        public void Test_CtorAqurium(string name, int cap)
        {
            Aquarium aquarium = new Aquarium(name, cap);
            Assert.That(aquarium.Name == name && aquarium.Capacity == cap);
        }

        [Test]
        public void Test_Field_Name()
        {
            Aquarium akvalandia = new Aquarium("Akvalandia", 10);
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(string.Empty, 10);
            }, "Name cannot be an empty string");
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium nullAquarium = new Aquarium(null, 8);
            }, "Name cannot be null");
        }

        [Test]
        public void Test_Field_Capacity()
        {
            Aquarium akvalandia = new Aquarium("Akvalandia", 10);

            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Gosho", -1);
            }, "Capacity cannot be below zero");
        }

        [Test]
        public void Test_Field_Count()
        {
            Aquarium akvalandia = new Aquarium("Akvalandia", 10);
            Fish gosho = new Fish("Gosho");
            Fish ilcho = new Fish("Ilcho");

            akvalandia.Add(gosho);
            akvalandia.Add(ilcho);

            Assert.AreEqual(2, akvalandia.Count);
        }

        [Test]
        public void Test_Method_Add()
        {
            Aquarium akvalandia = new Aquarium("Akvalandia", 1);
            Fish gosho = new Fish("Gosho");
            Fish ilcho = new Fish("Ilcho");

            akvalandia.Add(gosho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                akvalandia.Add(ilcho);
            }, "Capacity is full!");
        }

        [Test]
        public void Test_Method_Remove()
        {
            Aquarium akvalandia = new Aquarium("Akvalandia", 2);
            Fish gosho = new Fish("Gosho");
            Fish ilcho = new Fish("Ilcho");

            akvalandia.Add(gosho);
            akvalandia.Add(ilcho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                akvalandia.RemoveFish("Ilcho33");
            }, "Cannot find such fish");
            akvalandia.RemoveFish(gosho.Name);
            Assert.AreEqual(1, akvalandia.Count);
        }

        [Test]
        public void Test_Method_SellFish()
        {
            Aquarium akvalandia = new Aquarium("Akvalandia", 2);
            Fish gosho = new Fish("Gosho");
            Fish ilcho = new Fish("Ilcho");
            Fish fish = new Fish("Fish");

            akvalandia.Add(gosho);
            akvalandia.Add(ilcho);
            Assert.Throws<InvalidOperationException>(() =>
            {
               fish = akvalandia.SellFish("Ilcho33");
            }, "Cannot find such fish");
            gosho = akvalandia.SellFish(gosho.Name);
            Assert.That(gosho.Available, Is.False);  
        }

        [Test]
        public void Test_Method_Report()
        {
            Aquarium akvalandia = new Aquarium("Akvalandia", 2);
            Fish gosho = new Fish("Gosho");
            Fish ilcho = new Fish("Ilcho");
            Fish fish = new Fish("Fish");

            akvalandia.Add(gosho);
            akvalandia.Add(ilcho);
            gosho = akvalandia.SellFish(gosho.Name);
            string rep = "Gosho, Ilcho";
            string report = $"Fish available at {akvalandia.Name}: {rep}";
            string reporttocompare = akvalandia.Report();
            Assert.AreEqual(report, reporttocompare);
        }
    }
}
