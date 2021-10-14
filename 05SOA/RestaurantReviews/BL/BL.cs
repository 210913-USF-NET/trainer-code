using System;
using Models;
using System.Collections.Generic;
using DL;
using System.Threading.Tasks;

namespace RRBL
{
    public class BL : IBL
    {
        private IRepo _repo;

        //IRepo repo is the dependency of Business logic, that is being passed in aka "injected"
        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _repo.GetAllRestaurants();
        }

        public async Task<Restaurant> AddRestaurantAsync(Restaurant resto)
        {
            return await _repo.AddRestaurantAsync(resto);
        }

        public Restaurant UpdateRestaurant(Restaurant restoToUpdate)
        {
            //add logic to update restaurant
            return _repo.UpdateRestaurant(restoToUpdate);
        }

        public List<Restaurant> SearchRestaurant(string queryStr)
        {
            return _repo.SearchRestaurant(queryStr);
        }

        public async Task<Review> AddAReviewAsync(Review review)
        {
            return await _repo.AddAReviewAsync(review);
        }

        public Restaurant GetOneRestaurantById(int id)
        {
            return _repo.GetOneRestaurantById(id);
        }

        public async Task DeleteRestaurantAsync(int id)
        {
           await _repo.RemoveRestaurantAsync(id);
        }
    }
}
