using System;
using System.Collections.Generic;
using System.Linq;

namespace B_Day_celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int wastedAmoutOfFoot = 0;
            Queue<int> guests = new Queue<int>(firstLine);
            Stack<int> plates = new Stack<int>(secondLine);
            while (plates.Count > 0 && guests.Count > 0)
            {
                int guestToFeed = guests.Dequeue();
                int plateToServe = plates.Pop();
                guestToFeed -= plateToServe;
                if (guestToFeed <= 0)
                {
                    wastedAmoutOfFoot -= guestToFeed;
                }
                else
                {
                    while (guestToFeed>0&&plates.Count>0)
                    {
                        plateToServe = plates.Pop();
                        guestToFeed-=plateToServe;

                    }
                    wastedAmoutOfFoot-=guestToFeed;
                    //plateToServe = plates.Pop();
                    //plateToServe -= guestToFeed;
                    //wastedAmoutOfFoot += plateToServe;
                }

            }
            if (guests.Count > 0)
            {

                Console.WriteLine($"Guests: {string.Join(" ",guests)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(" ",plates)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedAmoutOfFoot}");

        }
    }
}
