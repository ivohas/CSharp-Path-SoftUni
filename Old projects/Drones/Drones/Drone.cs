using System.Text;

namespace Drones
{
    public class Drone
    {
        //        •	Name: string
        //•	Brand: string
        //•	Range: int
        //•	Available: boolean - true by default

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available = true;

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                       
            sb.AppendLine($"Drone: {Name}")
            .AppendLine($"Manufactured by: {Brand}")
            .AppendLine($" Range: {Range} kilometers");

            return sb.ToString();
        }
    }
}
