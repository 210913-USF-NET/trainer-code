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

        Review AddAReview(Review review);

        Restaurant GetOneRestaurantById(int id);

        Review GetOneReviewById(int id);

        void RemoveRestaurant(int id);
    }
}