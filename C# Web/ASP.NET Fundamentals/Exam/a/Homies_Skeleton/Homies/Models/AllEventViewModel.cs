using Microsoft.AspNetCore.Identity;

namespace Homies.Models
{
    public class AllEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Organiser { get; set; } = null!;

        public string? Description { get; set; }

        public string? End { get; set; }

        public string? CreatedOn { get; set; }

        public int? TypeId { get; set; }
        public List<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
