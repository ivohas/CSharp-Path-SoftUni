namespace Schedule.Data.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public Teacher Teacher { get; set; } = null!;
    }
}
