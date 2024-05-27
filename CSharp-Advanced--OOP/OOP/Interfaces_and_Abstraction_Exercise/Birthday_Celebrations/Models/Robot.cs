namespace Border_Control.Models
{
    using Models.Interfaces;
    public class Robot : IRobot
    {
        public string Model { get; private set; }
        public string ID { get; private set; }
    }
}
