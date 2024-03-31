using Gym.Core.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gym.Models.Gyms;
using Gym.Utilities.Messages;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;
        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.FirstOrDefault(n => n.Name == gymName);

            bool isAthletvalrd = ((athleteType == "Boxer") || (athleteType == "Weightlifter"));

            if ((gym.GetType().Name == "BoxingGym") && (athleteType == "Boxer"))
            {
                gym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
            }
            else if ((gym.GetType().Name == "WeightliftingGym") && (athleteType == "Weightlifter"))
            {
                gym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
            }
            else if (!isAthletvalrd)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            else
            {
                return "The gym is not appropriate.";
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment newEquipment = null;

            if (equipmentType == "BoxingGloves")
            {
                newEquipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                newEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(newEquipment as Equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym newGym = null;

            if (gymType == "BoxingGym")
            {
                newGym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                newGym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gyms.Add(newGym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(n => n.Name == gymName);

            double tottalWeight = gym.Equipment.Sum(x => x.Weight);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, tottalWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = this.gyms.FirstOrDefault(n => n.Name == gymName);
            IEquipment findEquipment = this.equipment.FindByType(equipmentType);

            if (findEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(findEquipment);
            this.equipment.Remove(findEquipment as Equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IGym gym in this.gyms)
            {
                //sb.AppendLine($"{gym.Name} is a {gym.GetType().Name}:");
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(n => n.Name == gymName);
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
