using Models;
using System.Collections.Generic;
using DL;
using System.Threading.Tasks;

namespace RRBL
{
    //this is an interface for all business logics i may or may not create
    //interface is a contract, all classes that implements an interface
    //must have the methods listed in the interface
    public interface IBL
    {
        List<Restaurant> GetAllRestaurants();

        Task<Restaurant> AddRestaurantAsync(Restaurant resto);

        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurantToUpdate);

        List<Restaurant> SearchRestaurant(string quertStr);

        Task<List<Review>> GetAllReviewsAsync();

        Task<Review> AddAReviewAsync(Review review);

        Task<Restaurant> GetOneRestaurantByIdAsync(int id);

        Task DeleteRestaurantAsync(int id);
    }
}