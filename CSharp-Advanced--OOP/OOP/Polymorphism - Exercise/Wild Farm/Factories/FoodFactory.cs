namespace Wild
{

    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int q)
        {
            Food food;
            if (type == "Vegetable")
            {
                food = new Vegetable(q);
            }
            else if (type == "Meat")
            {
                food = new Meat(q);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(q);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(q);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }

            return food;
        }
    }
}