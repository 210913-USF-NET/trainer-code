namespace DL
{
    public interface IRepo
    {
        Restaurant AddRestaurant();
        List<Restaurant> GetAllRestaurants();
    }
}