using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Articles
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void Edit(string newContent)
        {
            Content = newContent;
        }


        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine().Split(", ").ToArray();
            string title = arguments[0];
            string content = arguments[1];
            string author = arguments[2];

            int n = int.Parse(Console.ReadLine());

            Article article = new Article(title, content, author);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                string commandType = command[0];
                string commandValue = command[1];

                if (commandType == "Edit")
                {
                    article.Edit(commandValue);
                }
                if (commandType == "ChangeAuthor")
                {
                    article.ChangeAuthor(commandValue);
                }
                if (commandType == "Rename")
                {
                    article.Rename(commandValue);
                }
            }

            Console.WriteLine(article);


        }
    }
}
