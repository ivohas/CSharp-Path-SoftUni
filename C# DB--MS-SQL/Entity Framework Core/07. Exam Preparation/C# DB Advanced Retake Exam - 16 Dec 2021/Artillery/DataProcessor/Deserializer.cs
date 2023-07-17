namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Trucks.Utilities;

    public class Deserializer
    {
        
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";
        private static XmlHelper xmlHealper;

        // Good
        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            xmlHealper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            ImportCountriesDto[] contriesDto =
                xmlHealper.Deserialize<ImportCountriesDto[]>(xmlString, "Countries");

            ICollection<Country> validCounties =
                new HashSet<Country>();

            foreach (var country in contriesDto)
            {
                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Country countryValid = new Country { 
                  ArmySize = country.ArmySize,
                  CountryName = country.CountryName,
                
                };
                validCounties.Add(countryValid);
                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.AddRange(validCounties);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            xmlHealper=new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportManufacturerDto[] manufacturerDtos =
                xmlHealper.Deserialize<ImportManufacturerDto[]>(xmlString, "Manufacturers");

            ICollection<Manufacturer> validManufacturer =
                new HashSet<Manufacturer>();

            foreach (var m in manufacturerDtos)
            {

                var uniqueManufacturer = validManufacturer.FirstOrDefault(x => x.ManufacturerName == m.ManufacturerName);
                if (!IsValid(m)|| uniqueManufacturer!=null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturerValid = new Manufacturer { 
                 Founded = m.Founded,
                 ManufacturerName = m.ManufacturerName 
                };

                validManufacturer.Add(manufacturerValid);            
                var manufacturerCountry = m.Founded.Split(", ").ToArray();
                var last = manufacturerCountry.Skip(Math.Max(0, manufacturerCountry.Count() - 2)).ToArray();
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, m.ManufacturerName, string.Join(", ", last)));
            }
            context.AddRange(validManufacturer);
            context.SaveChanges();
            return sb.ToString();
        }
        // Good
        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            xmlHealper = new XmlHelper();

            ImportShellDto[] shellsDto = 
                xmlHealper.Deserialize<ImportShellDto[]>(xmlString, "Shells");

            ICollection<Shell> validShells =
                new List<Shell>();

            foreach (var shellDto in shellsDto)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell { 
                 ShellWeight = shellDto.ShellWeight,
                 Caliber = shellDto.Caliber
                
                };
                validShells.Add(shell);
                sb.AppendLine(String.Format(SuccessfulImportShell, shellDto.Caliber, shellDto.ShellWeight));
            }
            context.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };
            StringBuilder sb = new StringBuilder();
            var GunsDtos = JsonConvert.DeserializeObject<GunsDto[]>(jsonString);
            ICollection<GunsDto> validGuns = new List<GunsDto>();

            foreach (var GunD in GunsDtos)
            {
                if (!IsValid(GunD)||!validGunTypes.Contains(GunD.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                GunsDto validGun = new GunsDto
                {
                    ManufacturerId = GunD.ManufacturerId,
                    GunWeight = GunD.GunWeight,
                    BarrelLength= GunD.BarrelLength,
                    NumberBuild = GunD.NumberBuild,
                    Range= GunD.Range,
                    ShellId = GunD.ShellId,

                };

                foreach (var contry in GunD.Countries.Distinct())
                {
                   //validGun.Countries.Add(new ImportCountriesDto
                   //{
                   //    CountryId = countryDto.Id,
                   //    Gun = gun
                   //});
                }
            }
            return "";
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}