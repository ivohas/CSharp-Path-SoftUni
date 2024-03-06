using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        // Implement unit tests here
        [Test]
        public void InvalidGymNameNull()
        {



            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 5);

            }, "Invalid gym name.");
        }
        [Test]
        public void InvalidGymNameStringIsEmpty()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                var gym = new Gym(String.Empty, 5);


            }, "Invalid gym name.");
        }
        [Test]
        public void NameIsSettedCorrectly()
        {
            const string nameOfFitness = "Mania";
            Gym gym = new Gym("Mania", 19);
            Assert.That(nameOfFitness, Is.EqualTo(gym.Name));
        }
        [Test]
        public void CapacityBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var gym = new Gym("Mania", -1);

            }, "Invalid gym capacity.");
        }
        [Test]
        public void CapacityIsAllRightAndEverythingIsSetted()
        {
            const int gymCapacity = 19;
            Gym gym = new Gym("Mania", 19);
            Assert.That(gymCapacity, Is.EqualTo(gym.Capacity));
        }
        [Test]
        public void CantAddMoreGymBros() 
        {
            var gym = new Gym("Mania", 1);
            Athlete Nasko = new Athlete("Atanas");
            Athlete Dancho = new Athlete("Daniel");

            gym.AddAthlete(Nasko);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(Dancho);

            }, "The gym is full.");
        }
        [Test]
        public void TheAddWasSuccsesfull() 
        {
            var gym = new Gym("Mania", 3);
            Athlete Nasko = new Athlete("Atanas");
            Athlete Dancho = new Athlete("Daniel");

            gym.AddAthlete(Nasko);
            gym.AddAthlete(Dancho);

            Assert.That(gym.Count, Is.EqualTo(2));
        }
        [Test]
        public void InvalidRemoving() {
            const string athlethToRemove = "Gosho";
            var gym = new Gym("Mania", 2);
            Athlete Nasko = new Athlete("Atanas");
            Athlete Dancho = new Athlete("Daniel");

            gym.AddAthlete(Nasko);
            gym.AddAthlete(Dancho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(athlethToRemove);
            }, $"The athlete {athlethToRemove} doesn't exist.");
        }
        [Test]
        public void ValidRemoving() 
        {
            const string athlethToRemove = "Daniel";
            var gym = new Gym("Mania", 2);
            Athlete Nasko = new Athlete("Atanas");
            Athlete Dancho = new Athlete("Daniel");

            gym.AddAthlete(Nasko);
            gym.AddAthlete(Dancho);

            gym.RemoveAthlete(athlethToRemove);
            Assert.AreEqual(1, gym.Count);
           // Assert.That(athlethToRemove, Is.EqualTo(Dancho.FullName));
          
        }
        [Test]
        public void InvalidAthlethToGetInjury() 
        {
            const string fullName = "Gosho";
            var gym = new Gym("Mania", 2);
            Athlete Nasko = new Athlete("Atanas");
            Athlete Dancho = new Athlete("Daniel");

            gym.AddAthlete(Nasko);
            gym.AddAthlete(Dancho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete(fullName);
            }, $"The athlete {fullName} doesn't exist.");
        }
        [Test]
        public void AthlethGetsInjury() {
            const string fullName = "Atanas";
            var gym = new Gym("Mania", 2);
            Athlete Nasko = new Athlete("Atanas");
            Athlete Dancho = new Athlete("Daniel");

            gym.AddAthlete(Nasko);
            gym.AddAthlete(Dancho);

           
            var injured= gym.InjureAthlete(fullName);
            Assert.IsTrue(injured.IsInjured);
        }
        [Test]
        public void ReportTest() {
            const string fullName = "Atanas";
            var gym = new Gym("Mania", 2);
            Athlete Nasko = new Athlete("Atanas");
            Athlete Dancho = new Athlete("Daniel");

            gym.AddAthlete(Nasko);
            gym.AddAthlete(Dancho);
            gym.InjureAthlete(fullName);
             var report=gym.Report();
         
            var reportOriginal= $"Active athletes at Mania: Daniel";
            Assert.AreEqual(reportOriginal, report);
        }
    }
}
