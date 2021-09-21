using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Restaurant AddRestaurant(Restaurant resto);
        List<Restaurant> GetAllRestaurants();

        Restaurant UpdateRestaurant(Restaurant restaurantToUpdate);
    }
}