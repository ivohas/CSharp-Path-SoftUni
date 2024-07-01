using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        //        •	Name: string
        //•	Capacity: int
        //•	LandingStrip - double

        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int LandingStrip { get; set; }

        public Airfield(string name, int capacity, int landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }
        public int Count()
        {
            int n = 0;
            n = Drones.Count;
            return n;

        }
        public string AddDrone(Drone drone)
        {
            if (Capacity>Drones.Count)
            {
                if (drone.Name == null)
                {
                    return "Invalid drone.";
                }
                if (drone.Brand == null)
                {
                    return "Invalid drone.";
                }
                if (drone.Range<5||drone.Range>15)
                {
                    return "Invalid drone.";
                }
                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";

            }
            else
            {
                return "Airfield is full.";
            }
        }
        public bool RemoveDrone(string name)
        {
            foreach (Drone drone in Drones) 
            {
                if (drone.Name==name)
                {
                    return true;
                }
            }
            return false;
        }
        
        public Drone FlyDrone(string name)
        {
            foreach (var item in Drones)
            {
                if (item.Name==name)
                {
                    item.Available = false;
                    return item;
                }
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range) 
        { 
            List<Drone> drones = new List<Drone>();
            foreach (var item in Drones)
            {
                if (item.Range>=range)
                {
                    item.Available = false;
                    drones.Add(item);
                }
            }
            return drones;

        }
        public string Report() 
        {
            List<Drone>drones = new List<Drone>();
            foreach (var item in Drones)
            {
                if (item.Available==true)
                {
                    drones.Add(item);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in drones)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
        public int RemoveDroneByBrand(string brand) 
        {
            List<Drone>drones=new List<Drone>();
            int count = 0;
            foreach (var item in Drones)
            {
                if (item.Brand == brand)
                {
                    count++;
                }
                else 
                {
                    drones.Add(item);
                }
            }
            Drones = drones;
            if (count>0)
            {
                return count;
            }

            return 0;
        }

    }
}
