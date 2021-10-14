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

        Task<List<Review>> GetAllReviewsAsync();

        Task<Review> AddAReviewAsync(Review review);

        Restaurant GetOneRestaurantById(int id);

        Task RemoveRestaurantAsync(int id);
    }
}