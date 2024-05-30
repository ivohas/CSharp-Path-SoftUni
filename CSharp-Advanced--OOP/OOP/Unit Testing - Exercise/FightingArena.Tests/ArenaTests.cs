namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private string _name = "kukite me gonqt no ne mogat da me sprqt";
        
        [Test]
        public void TestCtor()
        {
            Arena testArena = new Arena();

            List<Warrior> collection = testArena.Warriors.ToList();
            List<Warrior> expectdCollection = new List<Warrior>();

            CollectionAssert.AreEqual(expectdCollection, collection,
                "Arena could have an empty collection of warriors");
        }

        [Test]
        public void TestEncapsulationOfWarriors()
        {
            string type = typeof(Arena).GetProperties().First(pi => pi.Name == "Warriors").PropertyType.Name;
            string expectdType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(expectdType, type,
                "current property should be of type IReadOnlyCollection<Warrior>!");
        }

        [Test]
        public void CountReturnsZero_Test()
        {
            Arena arena = new Arena();
            int count = arena.Count;
            int expctCoutn = 0;

            Assert.AreEqual(expctCoutn, count,
                "Count should return zero if there are no Warriors!");
        }

        [Test]
        public void Count_Tester()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Gosho", 50, 100);
            arena.Enroll(warrior);

            int count = arena.Count;
            int expctCoutn = 1;

            Assert.AreEqual(expctCoutn, count,
                "Count should return the count of the warriors!");
        }

        [Test]
        public void Test_Adder()
        {
            Arena arena = new Arena();
            Warrior ilcho = new Warrior("Ilcho", 30, 100);
            Warrior petio = new Warrior("Petio", 35, 85);

            arena.Enroll(ilcho);
            arena.Enroll(petio);

            List<Warrior> actualCollection = arena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>()
            {
                ilcho,
                petio
            };

            CollectionAssert.AreEqual(expectedCollection, actualCollection,
                "trq da vrushta warriors");
        }

        [Test]
        public void ShouldThrowException()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Kolio", 50, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            }, "Veche sa e bil toq");
        }

        [Test]
        public void Fight_ThrowException()
        {
            Warrior warrior = new Warrior("Kolio", 50, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Invalid", "Kolio");
            }, "ne go poznavam toq");
        }

        [Test]
        public void Fight_Test()
        {
            Warrior warrior = new Warrior("Kolio", 50, 100);
            Arena arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Kolio", "Invalid");
            }, "There is no such fighter");
        }

        [Test]
        public void Fight_Test_Success()
        {
            Warrior Fyretov33 = new Warrior("Fyre", 40, 100);
            Warrior GKangal = new Warrior("Gocata", 55, 100);
            Arena arena = new Arena();
            arena.Enroll(Fyretov33);
            arena.Enroll(GKangal);

            arena.Fight("Fyre", "Gocata");

            int actualAttackerHp = Fyretov33.HP;
            int expectedAttackerHp = 100 - GKangal.Damage;

            int defenderhp = GKangal.HP;
            int expectdDefHp = 100 - Fyretov33.Damage;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp,"should decrease current hp!");
            Assert.AreEqual(expectdDefHp, defenderhp,"should decrease current hp!");
        }
    }
}
