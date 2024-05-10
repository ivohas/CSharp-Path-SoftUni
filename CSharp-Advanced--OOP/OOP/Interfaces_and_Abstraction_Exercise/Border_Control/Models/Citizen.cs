namespace Border_Control
{
    using Models.Interfaces;
    public class Citizen : ICitizen
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }
    }
}
