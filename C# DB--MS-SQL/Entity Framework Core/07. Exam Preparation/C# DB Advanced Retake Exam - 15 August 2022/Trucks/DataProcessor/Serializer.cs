namespace Trucks.DataProcessor
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHealper;

        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
         xmlHealper = new XmlHelper();
            // Inclide
            ExportDespacherDto[] despachersDto = context.Despatchers
                .Include(d=> d.Trucks)
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespacherDto
                {
                    DespatcherName= d.Name,
                    TrucksCount=d.Trucks.Count,
                    Trucks= d.Trucks
                    .Select(t=> new ExportTruckDto{
                      RegistrationNumber= t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })  
                    .OrderBy(d => d.RegistrationNumber)
                    .ToArray()
                }) 
                .OrderByDescending(d=> d.Trucks.Count())
                .ThenBy(d=> d.DespatcherName)
                .ToArray();

            return xmlHealper.Serialize(despachersDto, "Despatchers").ToString();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Include(c=> c.ClientsTrucks)
                .ThenInclude(ct=> ct.Truck)
                .AsNoTracking()
                .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    Name=c.Name,
                    Trucks = c.ClientsTrucks
                    .Where(t => t.Truck.TankCapacity >= capacity)
                    .Select(t => new
                    {
                        TruckRegistrationNumber = t.Truck.RegistrationNumber,
                        VinNumber= t.Truck.VinNumber,
                        CargoCapacity = t.Truck.CargoCapacity.ToString(),
                        TankCapacity = t.Truck.TankCapacity,
                        MakeType= t.Truck.MakeType.ToString()
                    })
                    .ToArray()
                    .OrderBy(t=> t.MakeType)
                    .ThenByDescending(t=> t.CargoCapacity)
                })
                .OrderByDescending(t=> t.Trucks.Count())
                .ThenBy(t=> t.Name)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
