using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {

        [Key]
        public int Id { get; set; }

        [StringLength(8)]
     
        public string RegistrationNumber { get; set; }

        [Required]
        public string VinNumber  { get; set; }

        [Range(950,1420)]
        public int TankCapacity  { get; set; }

        [Range(5000,29000)]
        public int CargoCapacity  { get; set; }

        [Required]
        public CategoryType CategoryType  { get; set; }

        public MakeType MakeType  { get; set; }

        [Required]
        public int DespatcherId  { get; set; }

        public Despatcher Despatcher { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; } = new HashSet<ClientTruck>();
    }
}
