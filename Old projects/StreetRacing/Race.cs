using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    internal class Race
    {
        List<Car> Participants = new List<Car>();
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }
        public int Count()
        {
            return Participants.Count;
        }
        public void Add(Car car)
        {

            if (car.HorsePower <= MaxHorsePower && Capacity > Participants.Count)
            {
                foreach (Car participant in Participants)
                {
                    if (participant.LicensePlate == car.LicensePlate)
                    {
                        break;
                    }
                }
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            var toRemove = Participants.SingleOrDefault(x => x.LicensePlate == licensePlate);
            if (toRemove == null)
            {
                return false;
            }
            else
            {
                Participants.Remove(toRemove);
                return true;
            }

        }
        public string FindParticipant(string licensePlate)
        {
            var toRemove = Participants.SingleOrDefault(x => x.LicensePlate == licensePlate);
            if (toRemove == null)
            {
                return null;
            }
            else
            {
                return toRemove.ToString();
            }
        }
        public string GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
               var list= Participants.OrderByDescending(x => x.HorsePower).ToList();
                var mp = list[0];
               
               
                return mp.ToString();

            }
            else
            {
                return null;

            }




        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            int i = 0;
            foreach (var participant in Participants)
            {
                i++;
                if (i==Participants.Count)
                {
                    sb.Append(participant.ToString());
                }
                else
                {
                    sb.AppendLine(participant.ToString());

                }
                
               
            }
            return sb.ToString();

        }
    }
}
