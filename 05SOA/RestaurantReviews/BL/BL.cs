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

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restoToUpdate)
        {
            //add logic to update restaurant
            return await _repo.UpdateRestaurantAsync(restoToUpdate);
        }

        public List<Restaurant> SearchRestaurant(string queryStr)
        {
            return _repo.SearchRestaurant(queryStr);
        }


        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _repo.GetAllReviewsAsync();
        }

        public async Task<Review> AddAReviewAsync(Review review)
        {
            return await _repo.AddAReviewAsync(review);
        }

        public async Task<Restaurant> GetOneRestaurantByIdAsync(int id)
        {
            return await _repo.GetOneRestaurantByIdAsync(id);
        }

        public async Task<Review> GetOneReviewByIdAsync(int id)
        {
            return await _repo.GetOneReviewByIdAsync(id);
        }

        public async Task DeleteRestaurantAsync(int id)
        {
           await _repo.RemoveRestaurantAsync(id);
        }
    }
}
