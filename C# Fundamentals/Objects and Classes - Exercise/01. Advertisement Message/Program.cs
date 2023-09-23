using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Advertisement> list = new List<Advertisement>();

            List<string> Phrases = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            List<string> Events = new List<string>()
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            List<string> Authors = new List<string>()
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            List<string> Cities = new List<string>()
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            Random random = new Random();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int indexPhrase = random.Next(Phrases.Count);
                string randomPhrase = Phrases[indexPhrase];

                int indexEvent = random.Next(Phrases.Count);
                string randomEvent = Phrases[indexEvent];

                int indexAuthor = random.Next(Phrases.Count);
                string randomAuthor = Phrases[indexAuthor];

                int indexCity = random.Next(Phrases.Count);
                string randomCity = Phrases[indexCity];

                Advertisement advertisement = new Advertisement(randomPhrase, randomEvent, randomAuthor, randomCity);

                list.Add(advertisement);
            }

            foreach (Advertisement advertisement1 in list)
            {
                Console.WriteLine(advertisement1);
            }
        }
    }

    class Advertisement
    {
        public string Phrase { get; set; }

        public string Event { get; set; }

        public string Author { get; set; }

        public string City { get; set; }

        public Advertisement(string randomPhrase, string randomEvent, string randomAuthor, string randomCity)
        {
            this.Phrase = randomPhrase;
            this.Event = randomEvent;
            this.Author = randomAuthor;
            this.City = randomCity;
        }
        public override string ToString()
        {
            return $"{Phrase} {Event} {Author} - {City}.";
        }
    }
}
