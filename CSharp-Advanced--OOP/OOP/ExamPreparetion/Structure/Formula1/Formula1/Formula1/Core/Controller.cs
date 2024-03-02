using Formula1.Core.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Models;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        private PilotRepository pilotRepository;

        public Controller()
        {
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
            pilotRepository = new PilotRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = null;
               pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            IFormulaOneCar car = null;
                car= carRepository.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }
            pilot.AddCar(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race =raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            if (pilot == null || pilot.CanRace == false || race.Pilots.Contains(race.Pilots.FirstOrDefault(p => p.FullName == pilotFullName)))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type == "Ferrari" || type == "Williams")
            {
                if (carRepository.FindByName(model) != null)
                {
                    throw new InvalidOperationException($"Formula one car {model} is already created.");
                }
                if (type == "Ferrari")
                {
                    IFormulaOneCar ferrari = new Ferrari(model, horsepower, engineDisplacement);
                    carRepository.Add(ferrari);
                }
                else if (type == "Williams")
                {
                    IFormulaOneCar williams = new Williams(model, horsepower, engineDisplacement);
                    carRepository.Add(williams);
                }
                return $"Car {type}, model {model} is created.";
            }
            throw new InvalidOperationException($"Formula one car type {type} is not valid.");
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return $"Pilot {pilot.FullName} is created.";

        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName);
            if (race == null)
            {
                IRace raceToAdd = null;
                raceToAdd = new Race(raceName, numberOfLaps);
                raceRepository.Add(raceToAdd);
                return $"Race {raceName} is created.";
            }
            else
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine($"The {race.RaceName} race has: ")
                    .AppendLine($"Participants: {race.Pilots.Count}")
                    .AppendLine($"Number of laps: {race.NumberOfLaps}")
                    .AppendLine("Took place: Yes");                             
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            else
            {
                Dictionary<IPilot, double> points = new Dictionary<IPilot, double>();
                foreach (var pilot in race.Pilots)
                {
                    double point = pilot.Car.RaceScoreCalculator(race.NumberOfLaps);
                    points.Add(pilot, point);

                }


                var sb = new StringBuilder();
                int i = 0;
                foreach (var pilot in points.OrderByDescending(w => w.Value).Take(3))
                {
                    switch (i)
                    {
                        case 0:
                            pilot.Key.WinRace();
                            sb.AppendLine($"Pilot {pilot.Key.FullName} wins the {race.RaceName} race.");
                            break;
                        case 1:
                            sb.AppendLine($"Pilot {pilot.Key.FullName} is second in the {race.RaceName} race.");
                            break;
                        case 2:
                            sb.AppendLine($"Pilot {pilot.Key.FullName} is third in the {race.RaceName} race.");
                            break;
                        default:
                            break;
                    }
                    i++;
                }
                race.TookPlace = true;
                return sb.ToString();
            }


        }

    }
}
