using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split(", ").ToArray();

                string title = arguments[0];
                string content = arguments[1];
                string author = arguments[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }
            string filter = Console.ReadLine();

            if (filter == "content")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(x => x.Content)));
            }
            else if (filter == "title")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(x => x.Title)));
            }
            else if (filter == "author")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(x => x.Author)));
            }
        }
    }

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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
