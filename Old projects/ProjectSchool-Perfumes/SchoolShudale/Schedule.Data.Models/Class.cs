using BookFindingAndRatingSystem.Data.Models;

namespace Schedule.Data.Models
{
    public class Class
    {
        public Class()
        {
            Students = new List<ApplicationUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ApplicationUser> Students { get; set; }
        public ICollection<Teacher> Teacher { get; set; }
    }
}
