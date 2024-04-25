using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Card
    {
        string[] faces = "2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A".Split(", ");
        string[] suits = "S, H, D, C".Split(", ");
        Dictionary<char, string> sts = new Dictionary<char, string>()
            {
                {'S', "\u2660"},
                {'H', "\u2665"},
                {'D', "\u2666"},
                {'C', "\u2663"}
            };
        public Card(string face, string suit)
        {
            this.Face = face;
            this.suit = suit;
        }

        private string face;

        public string Face
        {
            get { return face; }
            set
            {
                face = value;
            }
        }

        private string suit;

        public string Suit
        {
            get { return suit; }
            set
            {
                 suit = value;
            }
        }
        public override string ToString()
        {
            return $"[{this.Face}{sts[char.Parse(this.Suit)]}]";
        }
    }

    public class Program
    {
        static void Main()
        {
            string[] faces = "2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A".Split(", ");
            string[] suits = "S, H, D, C".Split(", ");
            Dictionary<char, string> sts = new Dictionary<char, string>()
            {
                {'S', "\u2660"},
                {'H', "\u2665"},
                {'D', "\u2666"},
                {'C', "\u2663"}
            };

            List<Card> cardsList = new List<Card>();

            string[] cards = Console.ReadLine().Split(", ");
            for (int i = 0; i < cards.Length; i++)
            {
                string[] currCardInfo = cards[i].Split();
                string currFace = currCardInfo[0];
                string currSuit = currCardInfo[1];

                if (!faces.Contains(faces.FirstOrDefault(x => x == currFace)))
                {
                    Console.WriteLine("Invalid card!");
                    continue;
                }
                if (!suits.Contains(suits.FirstOrDefault(x => x == currSuit)))
                {
                    Console.WriteLine("Invalid card!");
                    continue;
                }
                else
                {
                    Card card = new Card(currFace, currSuit);
                    cardsList.Add(card);
                };
            }
            Console.WriteLine(String.Join(" ", cardsList));
        }
    }
}
