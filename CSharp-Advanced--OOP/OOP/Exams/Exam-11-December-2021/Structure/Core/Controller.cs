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
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            IAthlete athlete = null;
            switch (athleteType)
            {
                case nameof(Boxer):
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case nameof(Weightlifter):
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (gym.GetType().Name == nameof(BoxingGym) && athlete.GetType().Name == nameof(Boxer))
            {
                gym.AddAthlete(athlete);
            }
            else if (gym.GetType().Name == nameof(WeightliftingGym) && athlete.GetType().Name == nameof(Weightlifter))
            {
                gym.AddAthlete(athlete);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;
            switch (equipmentType)
            {
                case nameof(BoxingGloves):
                    equipment = new BoxingGloves();
                    break;
                case nameof(Kettlebell):
                    equipment = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            switch (gymType)
            {
                case nameof(BoxingGym):
                    gym = new BoxingGym(gymName);
                    break;
                case nameof(WeightliftingGym):
                    gym = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName) => $"{this.gyms.FirstOrDefault(g => g.Name == gymName).EquipmentWeight}";

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = this.gyms.FirstOrDefault(f => f.Name == gymName);

            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IGym gym in this.gyms)
            {
                sb.Append(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (IAthlete athlete in gym.Athletes)
            {
                athlete.Exercise();
            }
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
