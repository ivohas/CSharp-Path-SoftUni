using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Test_Weapon_Ctor()
            {
                string name = "Axe";
                double price = 25.42;
                int destructionLevel = 4;
                Weapon weapon = new Weapon(name, price, destructionLevel);
                
                Assert.That(weapon.Name == name && weapon.Price == price && weapon.DestructionLevel == destructionLevel);
            }

            [Test]
            public void Test_Weapon_Price_Exception()
            {
                string name = "Axe";
                double price = -1;
                int destructionLevel = 4;
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon(name, price, destructionLevel);
                }, "Price cannot be negative.");
            }

            [Test]
            public void Test_Weapon_Method_IncreaseDestructionLevel()
            {
                string name = "Axe";
                double price = 25.42;
                int destructionLevel = 4;
                Weapon weapon = new Weapon(name, price, destructionLevel);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel == destructionLevel + 1);
                Assert.That(!weapon.IsNuclear);
            }

            [Test]
            public void Test_Weapon_IsNuclear()
            {
                string name = "Axe";
                double price = 25.42;
                int destructionLevel = 10;
                Weapon weapon = new Weapon(name, price, destructionLevel);

                string name2 = "Hammer";
                double price2 = 25.42;
                int destructionLevel2 = 15;
                Weapon weapon2 = new Weapon(name2, price2, destructionLevel2);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.IsNuclear);
                Assert.That(weapon2.IsNuclear);
            }

            [Test]
            public void Test_Planet_Ctor()
            {
                string name = "Earth";
                double budget = 20.5;
                
                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                Assert.That(planet.Name == name && planet.Budget == budget && planet.Weapons.Count == 0);
            }

            [Test]
            public void Test_Planet_Name_Exception()
            {
                string name = "";
                string name2 = null;
                double budget = 20.5;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, budget);
                }, "Invalid planet Name");

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet2 = new Planet(name2, budget);
                }, "Invalid planet Name");
            }

            [Test]
            public void Test_Planet_Budget_Exception()
            {
                string name = "Earth";
                double budget = -1;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);
  
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, budget);
                }, "Invalid planet Name");
            }

            [Test]
            public void Test_Planet_MilitaryPowerRatio()
            {
                string name = "Earth";
                double budget = 20.5;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                Assert.That(planet.MilitaryPowerRatio == planet.Weapons.Sum(d => d.DestructionLevel));
            }

            [Test]
            public void Test_Planet_Method_Profit()
            {
                string name = "Earth";
                double budget = 20.5;
                double intialbudget = 20.5;
                double amount = 2.5;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                planet.Profit(amount);
                Assert.That(planet.Budget == intialbudget + amount);
            }

            [Test]
            public void Test_Planet_Method_SpendFunds()
            {
                string name = "Earth";
                double budget = 20.5;
                double intialbudget = 20.5;
                double amount = 2.5;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                planet.SpendFunds(amount);
                Assert.That(planet.Budget == intialbudget - amount);
            }

            [Test]
            public void Test_Planet_Method_AddWeapon()
            {
                string name = "Earth";
                double budget = 20.5;
                double amount = 2.5;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);
                planet.SpendFunds(amount);
                Assert.That(planet.Weapons.Count == 3);
            }

            [Test]
            public void Test_Planet_Method_AddWeapon_Exception()
            {
                string name = "Earth";
                double budget = 20.5;
                double amount = 2.5;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);
                Weapon weapon4 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon3);
                
                planet.SpendFunds(amount);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon4);
                }, "Invalid planet Name");
            }

            [Test]
            public void Test_Planet_Method_RemoveWeapon_Exception()
            {
                string name = "Earth";
                double budget = 20.5;
                double amount = 2.5;

                Weapon weapon1 = new Weapon("Axe", 9.5, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);
                Weapon weapon4 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon(weapon1.Name);

                planet.SpendFunds(amount);
                Assert.That(planet.Weapons.Count == 1);
            }

            [Test]
            public void Test_Planet_Method_UpgradeWeapon()
            {
                string name = "Earth";
                double budget = 20.5;
                double amount = 2.5;

                int destructionLevel = 9;
                Weapon weapon1 = new Weapon("Axe", 11.2, destructionLevel);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);
                Weapon weapon4 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.SpendFunds(amount);
                planet.UpgradeWeapon(weapon1.Name);
                Assert.That(weapon1.DestructionLevel == destructionLevel + 1);
            }

            [Test]
            public void Test_Planet_Method_UpgradeWeapon_Exception()
            {
                string name = "Earth";
                double budget = 20.5;
                double amount = 2.5;

                double destructionLevel = 9.5;
                Weapon weapon1 = new Weapon("Axe", destructionLevel, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);
                Weapon weapon4 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.SpendFunds(amount);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon($"{weapon1.Name}sd");
                }, "Invalid planet Name");
            }

            [Test]
            public void Test_Planet_Method_DestructOpponent()
            {
                string name = "Earth";
                double budget = 20.5;
                double amount = 2.5;

                double destructionLevel = 9.5;
                Weapon weapon1 = new Weapon("Axe", destructionLevel, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);
                Weapon weapon4 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                Planet planet2 = new Planet("VENERA", budget + 10);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.SpendFunds(amount);

                string output = planet.DestructOpponent(planet2);
                Assert.AreEqual(output, $"{planet2.Name} is destructed!");
            }

            [Test]
            public void Test_Planet_Method_DestructOpponent_Exception()
            {
                string name = "Earth";
                double budget = 20.5;
                double amount = 2.5;

                double destructionLevel = 9.5;
                Weapon weapon1 = new Weapon("Axe", destructionLevel, 11);
                Weapon weapon2 = new Weapon("Hammer", 12.5, 15);
                Weapon weapon3 = new Weapon("CrossBow", 20.5, 7);
                Weapon weapon4 = new Weapon("CrossBow", 20.5, 7);

                Planet planet = new Planet(name, budget);
                Planet planet2 = new Planet("VENERA", budget + 10);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.SpendFunds(amount);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet2.DestructOpponent(planet);
                }, "Invalid planet Name");
            }
            /*Assert.Throws<InvalidOperationException>(() =>
              {
                  fish = akvalandia.SellFish("Ilcho33");
              }, "Cannot find such fish");
            */
        }
    }
}
