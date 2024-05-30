namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void Array_Capacity()
        {
            Database data = new Database(
                (new Person(1242358235, "Gosho")),
                (new Person(12234234, "asd")),
                (new Person(56757435, "Goasdsho")),
                (new Person(58678678, "Gowersho")),
                (new Person(4565867967967, "fgh")),
                (new Person(69678856657, "hjk")),
                (new Person(9089078567567457, "nm,")),
                (new Person(34534675678, "tyuty")),
                (new Person(65856456, "jklgk")),
                (new Person(36547546, "fghstrsh")),
                (new Person(9774937776, "ghjghj")),
                (new Person(56734543656, "sdfsdyt")),
                (new Person(678967856674, "adgdew")),
                (new Person(34626453456547, "gurtry")),
                (new Person(5678567456456, "asdwefwe")),
                (new Person(35784567576456, "dfhfghrt")));

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(new Person(86795456546, "pugilji"));
                data.Add(new Person(1242358234235235, "asdwefawegfhfj"));
                data.Add(new Person(124567582358235, "fgjhdyjdtyd"));
            }, "Cannot exceed limit of data");
        }

        [Test]
        public void Array_AddRange()
        {
            Assert.That(() =>
            {
                Database data = new Database(
                (new Person(1242358235, "Gosho")),
                (new Person(12234234, "asd")),
                (new Person(56757435, "Goasdsho")),
                (new Person(58678678, "Gowersho")),
                (new Person(4565867967967, "fgh")),
                (new Person(69678856657, "hjk")),
                (new Person(9089078567567457, "nm,")),
                (new Person(34534675678, "tyuty")),
                (new Person(65856456, "jklgk")),
                (new Person(36547546, "fghstrsh")),
                (new Person(9774937776, "ghjghj")),
                (new Person(56734543656, "sdfsdyt")),
                (new Person(678967856674, "adgdew")),
                (new Person(34626453456547, "gurtry")),
                (new Person(5678567456456, "asdwefwe")),
                (new Person(35784567576456, "dfhfghrt")),

                (new Person(86795456546, "pugilji")),
                (new Person(1242358234235235, "asdwefawegfhfj")),
                (new Person(124567582358235, "fgjhdyjdtyd")));
            },
            Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void Array_Remove()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database data = new Database();
                data.Remove();
            }, "Array is empty");
        }

        [Test]
        public void Array_Constructor()
        {
            Database data = new Database();
            Person person = new Person(120312423, "Gosho");
            Person person2 = new Person(1256756712423, "Ilcho");
            data.Add(person);
            data.Add(person2);
            Assert.That(data.Count == 2);
        }

        [TestCase(103454823623)]
        [TestCase(103434423725)]
        public void Add(long id)
        {
            Database database = new Database();
            Person Gosho = new Person(id, "Gosho");
            Person Pesho = new Person(id, "Pesho");
            Person Gosho1 = new Person(id + 23, "Gosho");
            database.Add(Gosho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(Pesho);
            },
            "Cannot Add Person with already used ID");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(Gosho1);
            },
            "Cannot Add Person with already used Username");

            Person personToSuccess = new Person(id - 14, "gosho");
            int currDBCount = database.Count;
            database.Add(personToSuccess);
            Assert.That(database.Count, Is.EqualTo(currDBCount + 1));
        }

        [TestCase(103454823623)]
        [TestCase(103434423725)]
        public void FindByUsername(long id)
        {
            Database database = new Database();
            Person Gosho = new Person(id, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person personToFind = database.FindById(id);
            },
            "Username not found");

            Assert.Throws<ArgumentNullException>(() =>
            {
                Person personToFind = database.FindByUsername(null);
            },
            "Username cannot be null");
        }

        [TestCase(2356456456)]
        [TestCase(124235235234)]
        [TestCase(-23472374234)]
        [TestCase(-132124235235)]
        public void FindByID(long id)
        {
            Database database = new Database();
            Person Gosho = new Person(id, "Gosho");

            if (id <= 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    Person personToFind = database.FindById(id);
                },
                "Person with negative ID found (must own a positive ID)");
            }
            else
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    database.FindById(id + 1);
                },
                "Cannot find anyone in database with such ID");
            }
        }
    }
}