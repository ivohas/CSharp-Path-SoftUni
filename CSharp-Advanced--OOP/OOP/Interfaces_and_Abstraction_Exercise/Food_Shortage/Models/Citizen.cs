namespace Border_Control
{
    using Models.Interfaces;
    public class Citizen : ICitizen, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthdate;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get; private set; }
        public string BirthDate { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
