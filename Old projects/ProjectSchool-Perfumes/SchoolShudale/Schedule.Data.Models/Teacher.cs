namespace Schedule.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.Id = Guid.NewGuid();
            this.Subjects = new List<Subject>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Class> Classes { get; set; }
        public int NeededHours { get; set; }
    }
}
