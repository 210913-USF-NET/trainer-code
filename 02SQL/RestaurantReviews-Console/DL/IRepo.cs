using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Restaurant AddRestaurant(Restaurant resto);
        List<Restaurant> GetAllRestaurants();
        Restaurant UpdateRestaurant(Restaurant restaurantToUpdate);

        List<Restaurant> SearchRestaurant(string queryStr);

        Review AddAReview(Review review);

        Restaurant GetOneRestaurantById(int id);
    }
}