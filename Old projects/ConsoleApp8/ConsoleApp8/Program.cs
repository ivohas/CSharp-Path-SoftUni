using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> command = Console.ReadLine().Split().ToList();

             while (command[0] != "End") 
            {
                switch (command[0])
                {
                    case "Shoot":
                        int indexForShoot = int.Parse(command[1]);
                        int powerOfShoot = int.Parse(command[2]);
                        if (indexForShoot >= 0 && indexForShoot <= targets.Count)
                        {
                            if (targets[indexForShoot] >= powerOfShoot)
                            {
                                targets[indexForShoot] -= powerOfShoot;
                                if (targets[indexForShoot] <= 0)
                                {
                                    targets.RemoveAt(targets[indexForShoot]);
                                }
                            }
                            else 
                            {
                                targets.RemoveAt(targets[indexForShoot]);
                            }
                        }
                        break;
                    case "Add":
                        int indexToAdd = int.Parse(command[1]);
                        int numToAdd = int.Parse(command[2]);
                        if (indexToAdd >= 0 && indexToAdd <= targets.Count)
                        {
                            targets.Insert(indexToAdd, numToAdd);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");

                        }
                        break;
                    case "Strike":
                        int indexToStrike = int.Parse(command[1]);
                        int range = int.Parse(command[2]);

                        int up = indexToStrike;
                        int down = indexToStrike;
                        for (int i = 1; i <= range; i++)
                        {

                            down--;
                            if (down >= 0 && up <= targets.Count)
                            {
                                targets.RemoveAt(up);
                                targets.RemoveAt(down);
                                if (i == 1)
                                {
                                    targets.RemoveAt(indexToStrike);

                                }
                            }
                            else
                            {
                                Console.WriteLine("Strike missed!");
                                
                            }
                        }
                        break;
                    default:
                        break;
                        
                }
                command = Console.ReadLine().Split().ToList();

            } 

            Console.WriteLine(String.Join("|", targets));
        }
    }
}
