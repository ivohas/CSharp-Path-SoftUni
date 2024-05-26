namespace Wild
{
    public class StartUp
    {
        static void Main()
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(foodFactory, animalFactory);
            engine.Start();
        }
    }
}