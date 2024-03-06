namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class AquariumsTests
    {
        [Test]
        public void NameArgumentNullExeptionStringEmpty()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(string.Empty, 10);
            },
            "Invalid aquarium name!");
        }

        [Test]
        public void NameArgumentNullExeptionNullGiven()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(null, 10);
            },
            "Invalid aquarium name!");
        }

        [Test]
        public void NameValueIsSet()
        {

            const string name = "Aqua";
            Aquarium aquarium = new Aquarium(name, 10);
            Assert.That(aquarium.Name, Is.EqualTo(name));

        }
        [Test]
        public void InvalidAquariumCapacityThatIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("Aqua", -10);

            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void AddExeptionAquariumIsFull()
        {
            Aquarium aqua = new Aquarium("AquaParadase", 2);
            Fish fish = new Fish("Vanko");
            Fish fish1 = new Fish("Petar");
            Fish fish2 = new Fish("Gosho");


            aqua.Add(fish);
            aqua.Add(fish1);

            Assert.Throws<InvalidOperationException>(() =>
            {

                aqua.Add(fish2);

            }, "Aquarium is full!");
        }

        [Test]
        public void AddFishInAquariumProperly() {
            const int fishInAquarium = 2;


            Aquarium aqua = new Aquarium("AquaParadase", 2);
            Fish fish = new Fish("Vanko");
            Fish fish1 = new Fish("Petar");

            aqua.Add(fish);
            aqua.Add(fish1);
            Assert.That(aqua.Count, Is.EqualTo(fishInAquarium));

        }
        [Test]
        public void RemoveFishProperly() {
            const string fishToRemove = "Nemo";
            Aquarium aquaParadise = new Aquarium("AquaParadise",3);
            Fish firstFish = new Fish("Dori");
            Fish secondFish = new Fish("Octo");
            Fish thirdFish = new Fish("Nemo");
            aquaParadise.Add(firstFish);
            aquaParadise.Add(secondFish);
            aquaParadise.Add(thirdFish);
            Assert.That(fishToRemove,Is.EqualTo(thirdFish.Name));

        }
        [Test]
        public void RemoveCarProblemInWhichCarDoesntExist()
        {
            const string fishToRemove = "Nemo";
            Aquarium aquaParadise = new Aquarium("AquaParadise", 3);
            Fish firstFish = new Fish("Dori");
            Fish secondFish = new Fish("Octo");
            Fish thirdFish = new Fish("Nemo");
            aquaParadise.Add(firstFish);
            aquaParadise.Add(secondFish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquaParadise.RemoveFish(fishToRemove);


            }, $"Fish with the name {fishToRemove} doesn't exist!");
        }
        [Test]
        public void FishToSellIsNull() {

            const string fishToSell = "Nemo";

            Aquarium aquaParadise = new Aquarium("AquaParadise", 3);
            Fish firstFish = new Fish("Dori");
            Fish secondFish = new Fish("Octo");
            Fish thirdFish = new Fish("Nemo");

            aquaParadise.Add(firstFish);
            aquaParadise.Add(secondFish);
    
            Assert.Throws<InvalidOperationException>(() =>
            {

                aquaParadise.RemoveFish(fishToSell);

            }, $"Fish with the name {fishToSell} doesn't exist!");

        }
        [Test]
        public void FishToSell() 
        {

            const string fishToSell = "Nemo";
            Aquarium aquaParadise = new Aquarium("AquaParadise", 3);
            Fish firstFish = new Fish("Dori");
            Fish secondFish = new Fish("Octo");
            Fish thirdFish = new Fish("Nemo");

            aquaParadise.Add(thirdFish);
            aquaParadise.Add(firstFish);

           Fish fish=   aquaParadise.SellFish(fishToSell);
            Assert.IsFalse(fish.Available);
           
            
        }
        [Test]
        public void ReportCheck()
        {
            
            Aquarium aquaParadise = new Aquarium("AquaParadise", 3);
            Fish firstFish = new Fish("Dori");
            Fish secondFish = new Fish("Octo");
            Fish thirdFish = new Fish("Nemo");
            aquaParadise.Add(thirdFish);
            aquaParadise.Add(firstFish);
            var checkReport = aquaParadise.Report();
            Assert.That(checkReport, Is.EqualTo($"Fish available at AquaParadise: Nemo, Dori"));
        }
    }
}
