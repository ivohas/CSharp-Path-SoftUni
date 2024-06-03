using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theatre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int years = int.Parse(Console.ReadLine());
            if (day == "Weekday")
            {
                if (0 <= years && years <= 18)
                {
                    Console.WriteLine("12$");
                }
                else
                {
                    if (18 < years && years >= 64)
                    {
                        Console.WriteLine("18$");
                    }
                    else
                    {
                        if (64 < years && years >= 122)
                        {
                            Console.WriteLine("12$");
                        }

                    }
                }
            }
            else { if (day == "Weekend")
                {


                    if (0 <= years && years <= 18)
                    {
                        Console.WriteLine("15$");
                    }
                    else
                    {
                        if (18 < years && years >= 64)
                        {
                            Console.WriteLine("20$");
                        }
                        else
                        {
                            if (64 < years && years >= 122)
                            {
                                Console.WriteLine("15$");
                            }
                        }



                        }
                        if (day == "Holiday")
                        {
                            if (0 <= years && years <= 18)
                            {
                                Console.WriteLine("5$");
                            }
                            else
                            {
                                if (18 < years && years >= 64)
                                {
                                    Console.WriteLine("12$");
                                }
                                else
                                {
                                    if (64 < years && years >= 122)
                                    {
                                        Console.WriteLine("10$");
                                    }
                                }
                            }
                        }
                        else {
                            Console.WriteLine("Error!");
                        
                    }
                }
            } }
    }
}
