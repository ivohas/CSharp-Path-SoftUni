namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test_Ctor()
        {
            string name = "Metro 2033";
            string author = "Dmitrii Glukhovski";

            Book book = new Book(name, author);

            Assert.That(book.Author == author && book.BookName == name);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_BookName_Exception(string name)
        {
            string author = "Dmitrii Glukhovski";


            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, author);
            }, "BookName cannot be null or empty");
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_AuthorName_Exception(string author)
        {
            string name = "Metro 2033";

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, author);
            }, "AuthorName cannot be null or empty");
        }

        [Test]
        public void Test_Method_AddFootnote()
        {
            string name = "Metro 2033";
            string author = "Dmitrii Glukhovski";

            int footNoteNumber = 4;
            string text = "Opaaa";

            Book book = new Book(name, author);

            book.AddFootnote(footNoteNumber, text);

            Assert.That(book.FootnoteCount == 1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(footNoteNumber, text);
            }, "FootNote already exists");
        }

        [Test]
        public void Test_Method_FindFootnote()
        {
            string name = "Metro 2033";
            string author = "Dmitrii Glukhovski";

            int footNoteNumber = 4;
            string text = "Opaaa";

            Book book = new Book(name, author);

            book.AddFootnote(footNoteNumber, text);
            string textToSearch = $"Footnote #{footNoteNumber}: {text}";


            Assert.That(textToSearch == book.FindFootnote(footNoteNumber));

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(footNoteNumber + 1);
            }, "FootNote not found");
        }

        [Test]
        public void Test_Method_AlterFootnote()
        {
            string name = "Metro 2033";
            string author = "Dmitrii Glukhovski";

            int footNoteNumber = 4;
            string text = "Opaaa";
            string text2 = text + " Kole";
            Book book = new Book(name, author);

            book.AddFootnote(footNoteNumber, text);
            string textToSearch = $"Footnote #{footNoteNumber}: {text2}";

            book.AlterFootnote(footNoteNumber, text2);

            Assert.That(textToSearch == book.FindFootnote(footNoteNumber));

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(footNoteNumber + 1 , textToSearch);
            }, "FootNote not found");
        }
    }
}