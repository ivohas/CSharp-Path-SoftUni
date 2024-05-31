namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Reflection;
    using System;
    using System.Linq;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Test_Ctor()
        {
            string Name = "Kolio";
            int dmg = 55;
            int hp = 33;

            Warrior warrior = new Warrior(Name, dmg, hp);

            FieldInfo nameField = this.GetField("name");
            string actualName = (string)nameField.GetValue(warrior);

            FieldInfo damageField = this.GetField("damage");
            int actualDamage = (int)damageField.GetValue(warrior);

            FieldInfo hpField = this.GetField("hp");
            int actualHp = (int)hpField.GetValue(warrior);

            Assert.AreEqual(Name, actualName,
                "Constructor should have the Name of the Warrior!");
            Assert.AreEqual(dmg, actualDamage,
                "Constructor should have the Damage of the Warrior!");
            Assert.AreEqual(hp, actualHp,
                "Constructor should have the HP of the Warrior!");
        }

        [Test]
        public void TestNameGetter()
        {
            string name = "Kolio";
            Warrior warrior = new Warrior(name, 55, 33);

            string actualName = warrior.Name;

            Assert.AreEqual(name, actualName,
                "getter should return value!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("        ")]
        public void testSetter(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 55, 55);
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        public void testDMGGetter()
        {
            int dmg = 55;
            Warrior warrior = new Warrior("Kolio", dmg, 33);

            int actDMG = warrior.Damage;

            Assert.AreEqual(dmg, actDMG,
                "getter should return value!");
        }

        [TestCase(-4)]
        [TestCase(-2)]
        [TestCase(0)]
        public void testDMGSetterValidator(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Kolio", damage, 55);
            }, "Damage should be positive!");
        }

        [Test]
        public void TestHP_Getter()
        {
            int hp = 55;
            Warrior warrior = new Warrior("Kolio", 33, hp);

            int actualHP = warrior.HP;

            Assert.AreEqual(hp, actualHP,
                "getter should return value of hp");
        }

        [TestCase(-3)]
        [TestCase(-2)]
        public void TestHPSetterValidation(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 55, hp);
            }, "HP shouldn't be negative!");
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(25)]
        public void AttackErrors_Test(int startHP)
        {
            Warrior us = new Warrior("Kolio", 70, startHP);
            Warrior fyreto = new Warrior("GKangal", 55, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                us.Attack(fyreto);
            }, "slab si");
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(25)]
        public void AttaackError(int startHP)
        {
            Warrior us = new Warrior("Kolio", 45, 65);
            Warrior fyre = new Warrior("Mustio", 35, startHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                us.Attack(fyre);
            }, "slab si we");
        }

        [TestCase(50, 60)]
        [TestCase(50, 51)]
        public void attack1(int attackerHp, int defenderDamage)
        {
            Warrior us = new Warrior("Kolio", 50, attackerHp);
            Warrior fyre = new Warrior("fyreto", defenderDamage, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                us.Attack(fyre);
            }, "slab si be");
        }

        [TestCase(70, 50)]
        [TestCase(60, 55)]
        [TestCase(60, 60)]
        public void SuccessAttackShouldDecreaseAttackerHP(int attackerHp, int dfdmg)
        {
            //Arrange
            Warrior us = new Warrior("Kolio", 50, attackerHp);
            Warrior fyre = new Warrior("fyreto", dfdmg, 55);

            //Act
            us.Attack(fyre);

            int hp = us.HP;
            int exchp = attackerHp - dfdmg;

            Assert.AreEqual(exchp, hp,
                "razgele");
        }

        [TestCase(70, 40)]
        [TestCase(60, 55)]
        [TestCase(60, 59)]
        public void successAttack(int attdmg, int defenderHp)
        {
            //Arrange
            Warrior us = new Warrior("Kolio", attdmg, 100);
            Warrior fyreto = new Warrior("fyreto", 40, defenderHp);

            //Act
            us.Attack(fyreto);

            int actualDefenderHp = fyreto.HP;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp,
                "zapri");
        }

        [TestCase(50, 100)]
        [TestCase(50, 60)]
        [TestCase(50, 51)]
        [TestCase(50, 50)]
        public void attackError22(int attackerDamage, int defenderHp)
        {
            //Arrange
            Warrior fyre = new Warrior("kolio", attackerDamage, 100);
            Warrior us = new Warrior("angel", 30, defenderHp);

            //Act
            fyre.Attack(us);

            int actualDefenderHp = us.HP;
            int expectedDefenderHp = defenderHp - attackerDamage;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp,
                "dad a");
        }

        private FieldInfo GetField(string fieldName)
            => typeof(Warrior)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == fieldName);
    }
}