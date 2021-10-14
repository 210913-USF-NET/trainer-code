using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IRepo
    {
        Task<Restaurant> AddRestaurantAsync(Restaurant resto);
        List<Restaurant> GetAllRestaurants();
        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurantToUpdate);

        List<Restaurant> SearchRestaurant(string queryStr);

        Review AddAReview(Review review);

        Restaurant GetOneRestaurantById(int id);

        void RemoveRestaurant(int id);
    }
}