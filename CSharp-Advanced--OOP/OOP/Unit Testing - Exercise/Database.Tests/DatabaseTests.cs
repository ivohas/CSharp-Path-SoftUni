namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Array_Capacity()
        {
            Assert.That(() =>
            {
                Database data = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
                Database opop = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            },
            Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Array_Add()
        {
            Assert.That(() =>
            {
                Database data = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
                data.Add(17);
            },
            Throws.Exception.TypeOf<InvalidOperationException>());
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
            Database data = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.That(data.Count == 16);
        }

        [Test]
        public void Array_Fetch()
        {
            int[] testData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database data = new Database();
            foreach (int el in testData)
            {
                data.Add(el);
            }

            int[] actualResult = data.Fetch();

            CollectionAssert.AreEqual(testData, actualResult,
                "Fetch should return copy of the existing data!");
        }
    }
}
