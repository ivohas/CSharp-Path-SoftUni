using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<string,int>toBuild=new Dictionary<string,int>();
            toBuild.Add("Countertop", 0);
            toBuild.Add("Floor", 0);
            toBuild.Add("Oven", 0);
            toBuild.Add("Sink", 0);
            toBuild.Add("Wall", 0);
            Queue<int>grey=new Queue<int>(secondLine);
            Stack<int> white=new Stack<int>(firstLine);
            while (white.Count>0&& grey.Count>0)
            {
                int sumArea = 0;
                int singleGreyPiece=grey.Dequeue();
                int singleWhitePiece = white.Pop();
                if (singleGreyPiece==singleWhitePiece)
                {
                        sumArea= singleGreyPiece +singleWhitePiece;
                }
                else
                {
                    singleWhitePiece = singleWhitePiece / 2;
                    white.Push(singleWhitePiece);
                    grey.Enqueue(singleGreyPiece);

                }
              
                if (sumArea==40)
                {
                    toBuild["Sink"] += 1;
                }
                else if(sumArea==50)
                {
                    toBuild["Oven"] += 1; 
                }
                else if (sumArea==60)
                {
                    toBuild["Countertop"] += 1;
                }
                else if (sumArea==70)
                {
                    toBuild["Wall"] += 1;
                }
                else if (sumArea>0)
                {
                    toBuild["Floor"] += 1;

                }
               
            }
            if (white.Count>0)
            {
                Console.WriteLine("White tiles left: "+String.Join(", ",white) );
            }
            else
            {

                Console.WriteLine("White tiles left: none");
            }
            if (grey.Count>0)
            {
                Console.WriteLine("Grey tiles left: "+ String.Join(", ",grey));
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }
           
            IOrderedEnumerable<KeyValuePair<string, int>> sortedCollection = toBuild.Where(x => x.Value > 0)
                     .OrderByDescending(x => x.Value)
                     .ThenBy(x => x.Key);
            foreach (var item in sortedCollection)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
