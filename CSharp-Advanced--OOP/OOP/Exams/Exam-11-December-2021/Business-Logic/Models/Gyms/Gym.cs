using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public double EquipmentWeight => this.Equipment.Sum(e => e.Weight);

        private ICollection<IEquipment> equipment;

        public ICollection<IEquipment> Equipment
        {
            get { return equipment; }
        }

        private ICollection<IAthlete> athletes;

        public ICollection<IAthlete> Athletes
        {
            get { return athletes; }
        }


		public void AddAthlete(IAthlete athlete)
		{
			if (this.Athletes.Count >= this.Capacity)
			{
				throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
			}

			this.athletes.Add(athlete);
		}

        public void AddEquipment(IEquipment equipment) => this.equipment.Add(equipment);

		public void Exercise()
		{
			foreach (IAthlete athlete in this.athletes)
			{
				athlete.Exercise();
			}
		}

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            string athletesAsString = this.Athletes.Any() ? string.Join(", ", this.Athletes.Select(x => x.FullName)) : "No athletes";

            sb
                .AppendLine($"{this.Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {athletesAsString}")
                .AppendLine($"Equipment total count: {this.Equipment.Count}")
                .AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) => this.Athletes.Remove(athlete);
    }
}
