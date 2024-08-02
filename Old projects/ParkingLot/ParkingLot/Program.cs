using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parking = new HashSet<string>();
            while (true)
            {
                string number = Console.ReadLine();
                if (number == "END")
                {
                    break;
                }
                var tokens = number.Split(',').ToList();
                string command = tokens[0];
                string carNum = tokens[1];
                if (command == "IN")
                {
                    parking.Add(carNum);
                }
                else
                {
                    parking.Remove(carNum);
                }


            }
            if (parking.Count > 0)
            {
                foreach (var num in parking)
                {
                    Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
