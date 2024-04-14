using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.Vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = this.vessels.FindByName(attackingVesselName);
            IVessel defender = this.vessels.FindByName(defendingVesselName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defender == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            this.captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this.vessels.FindByName(name);

            if (vessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            switch (vesselType)
            {
                case nameof(Battleship):
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                case nameof(Submarine):
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
                default:
                    return OutputMessages.InvalidVesselType;
            }

            this.vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel != null)
            {
                switch (vessel.GetType().Name)
                {
                    case nameof(Battleship):
                        Battleship battleship = (Battleship)vessel;
                        battleship.ToggleSonarMode();
                        return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                    case nameof(Submarine):
                        Submarine submarine = (Submarine)vessel;
                        submarine.ToggleSubmergeMode();
                        return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                    default:
                        return OutputMessages.InvalidVesselType;
                }
            }

            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}
