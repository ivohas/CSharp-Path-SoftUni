using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new HashSet<string>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(", ");

                if (command[0] == "END")
                    break;  
                if (command[0] == "IN")
                    parkingLot.Add(command[1]);
                else if (command[0] == "OUT")
                    parkingLot.Remove(command[1]);

            }

            if (parkingLot.Any())
            {
                foreach (string car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else Console.WriteLine("Parking Lot is Empty");

        }
    }
}
