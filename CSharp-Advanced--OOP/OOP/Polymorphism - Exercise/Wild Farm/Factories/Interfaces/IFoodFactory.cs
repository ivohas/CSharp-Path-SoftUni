namespace Wild
{

    public interface IFoodFactory
    {
        Food CreateFood(string type, int q);
    }
}