using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AxeCannotAttackIfBroken()
        {
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);
            TestDelegate name;
            name = () => axe.Attack(dummy);

            Assert.Catch(name);
        }

        [Test]
        public void DummyCannotBeHit()
        {
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(1, 1);

            axe.Attack(dummy);
            TestDelegate name;
            name = () => axe.Attack(dummy);
            Assert.Catch(name);
        }
    }   
}