using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealth()
        {
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(10, 10);
            int dummyStartHP = dummy.Health;

            axe.Attack(dummy);
            Assert.That(dummy.Health == dummyStartHP - axe.AttackPoints);
        }

        [Test]
        public void DummyThrowsAnExceptionIfDeadAndAttacked()
        {
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(5, 5);

            axe.Attack(dummy);
            TestDelegate test;
            test = () => axe.Attack(dummy);
            Assert.Catch(test);
        }

        [Test]
        public void DummyGivesXPAfterDeath()
        {
            Axe axe = new Axe(5, 5);
            int dummyXP = 5;
            Dummy dummy = new Dummy(5, dummyXP);
                      
            axe.Attack(dummy);

            Assert.That(dummy.GiveExperience() == dummyXP);
        }

        [Test]
        public void DummyDoesntGiveXP()
        {
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(6, 5);

            axe.Attack(dummy);

            Assert.That(() =>
            {
                dummy.GiveExperience();
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
             "Target is not dead.");
        }
    }
}