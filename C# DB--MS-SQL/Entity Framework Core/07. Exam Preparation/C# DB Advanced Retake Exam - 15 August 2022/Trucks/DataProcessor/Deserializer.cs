namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    { 
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        private static XmlHelper xmlHealper;

     

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            xmlHealper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            DespatcherDto[] despatcherDtos =
                xmlHealper.Deserialize<DespatcherDto[]>(xmlString, "Despatchers");

            ICollection<Despatcher> validDespatcher = new HashSet<Despatcher>();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                ICollection<Truck> validTrucks = new HashSet<Truck>();

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Truck validTruck = new Truck
                    {
                        RegistrationNumber= truckDto.RegistrationNumber,
                        VinNumber= truckDto.VinNumber,
                        CargoCapacity= truckDto.CargoCapacity,
                        TankCapacity= truckDto.TankCapacity,
                        CategoryType= (CategoryType)truckDto.CategoryType,
                        MakeType= (MakeType)truckDto.MakeType
                    };
                    validTrucks.Add(validTruck);
                }
                Despatcher despatcher = new Despatcher
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };
               
                validDespatcher.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }
            context.Despatchers.AddRange(validDespatcher);
            context.SaveChanges();
            return sb.ToString();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ClientDto[] clientsDto = JsonConvert.DeserializeObject<ClientDto[]>(jsonString);

            ICollection<Client> validClients = new HashSet<Client>();
            ICollection<int> existingTruckId = context.Trucks
                .Select(t => t.Id)
                .ToArray();
            foreach (var clientDto in clientsDto)
            {
                if (!IsValid(clientsDto)||clientDto.Name.Length>40)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (clientDto.Type=="usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client client = new Client
                {
                    Name= clientDto.Name,
                    Nationality= clientDto.Nationality,
                    Type= clientDto.Type
                };
                foreach (var truckId in clientDto.TrucksId.Distinct())
                {
                    if (!existingTruckId.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    ClientTruck ct = new ClientTruck
                    {
                        Client= client,
                        TruckId= truckId
                    };
                    client.ClientsTrucks.Add(ct);
                }
                validClients.Add(client);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }
            context.Clients.AddRange(validClients);
            
           context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}