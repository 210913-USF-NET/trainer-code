using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IRepo
    {
        Task<Restaurant> AddRestaurantAsync(Restaurant resto);
        List<Restaurant> GetAllRestaurants();
        Restaurant UpdateRestaurant(Restaurant restaurantToUpdate);

        List<Restaurant> SearchRestaurant(string queryStr);

        Task<Review> AddAReviewAsync(Review review);

        Restaurant GetOneRestaurantById(int id);

        Task RemoveRestaurantAsync(int id);
    }
}