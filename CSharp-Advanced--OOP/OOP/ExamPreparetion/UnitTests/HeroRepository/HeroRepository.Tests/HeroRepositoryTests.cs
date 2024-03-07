using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void InvalidCreateNameIsNull() {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = null ;
        Assert.Throws<ArgumentNullException > (() => { 
        
           heroRepository.Create(hero);
        }, "Hero is null");
    }
    [Test]
    public void InvalidCreateTheNameAlreadyExeist() {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("SuperMan",100);
        Hero hero2 = new Hero("Batman", 72);
        Hero hero3 = new Hero("SuperMan", 120);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        Assert.Throws<InvalidOperationException>(() => {
        
            heroRepository.Create(hero3);
        }, $"Hero with name {hero3.Name} already exists");
    }
    [Test]
    public void SuccsesfullyCreatedHero() {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("SuperMan", 100);
        Hero hero2 = new Hero("Batman", 72);
        Hero hero3 = new Hero("SuperMan", 120);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        Assert.AreEqual(2,heroRepository.Heroes.Count);
    }
    [Test]
    public void InvaidRemoveHeroNameIsNull() {
        const string heroToRemove = null;
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("SuperMan", 100);
        Hero hero2 = new Hero("Batman", 72);
        Hero hero3 = new Hero("SuperMan", 120);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        Assert.Throws<ArgumentNullException>(() => {

            heroRepository.Remove(heroToRemove);
        });
    }
    [Test]
    public void RemovingIsOk() {
        const string heroToRemove = "SuperMan";
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("SuperMan", 100);
        Hero hero2 = new Hero("Batman", 72);
        Hero hero3 = new Hero("SuperMan", 120);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        bool isTrue = heroRepository.Remove(heroToRemove);
        Assert.IsTrue(isTrue);
    }
    [Test]
    public void GetTheHeroWithTheHisherstLevel() {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("SuperMan", 100);
        Hero hero2 = new Hero("Batman", 72);
        Hero hero3 = new Hero("Dr. Strange", 120);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        Hero mostPowerfull = heroRepository.GetHeroWithHighestLevel();
        Assert.That(mostPowerfull.Level, Is.EqualTo(hero3.Level)) ;
    }
    [Test]
    public void GetHero()
    {
        const string heroToGet = "Dr. Strange";
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("SuperMan", 100);
        Hero hero2 = new Hero("Batman", 72);
        Hero hero3 = new Hero("Dr. Strange", 120);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        var GettedHero = heroRepository.GetHero(heroToGet);
        Assert.AreEqual(GettedHero.Name, heroToGet);
    }
}