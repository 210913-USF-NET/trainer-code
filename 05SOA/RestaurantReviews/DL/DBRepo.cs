using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
//using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private RRDBContext _context;
        public DBRepo(RRDBContext context)
        {
            _context = context;
        }
        public async Task<Restaurant> AddRestaurantAsync(Restaurant resto)
        {
            //this method adds the restoToAdd obj to change tracker
            await _context.AddAsync(resto);

            //the "changes" don't get executed until you call the SaveChanges method
            await _context.SaveChangesAsync();

            //this clears the changetracker so it returns to a clean slate
            _context.ChangeTracker.Clear();

            return resto;
        }

        public Restaurant AddRestaurant(Restaurant resto)
        {
            //this method adds the restoToAdd obj to change tracker
            _context.Add(resto);

            //the "changes" don't get executed until you call the SaveChanges method
            _context.SaveChanges();

            //this clears the changetracker so it returns to a clean slate
            _context.ChangeTracker.Clear();

            return resto;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            //select * from Restaurants in sql query
            //Gets the Entities.Restaurant
            //and we have to convert it to Model.Restaurant
            //.Select() is similar in behavior to .map() is js
            return _context.Restaurants
                .Include("Reviews")
                .Select(
                restaurant => new Restaurant() {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    State = restaurant.State,
                    City = restaurant.City
                }
            ).ToList();

            //same result, in query syntax
            // return (from resto in _context.Restaurants select new Model.Restaurant(){
            //     Id = resto.Id,
            //     Name = resto.Name,
            //     State = resto.State,
            //     City = resto.City
            // }).ToList();
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurantToUpdate)
        {

            _context.Restaurants.Update(restaurantToUpdate);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return new Restaurant() {
                Id = restaurantToUpdate.Id,
                Name = restaurantToUpdate.Name,
                City = restaurantToUpdate.City,
                State = restaurantToUpdate.State
            };
        }

        public List<Restaurant> SearchRestaurant(string queryStr)
        {
            return _context.Restaurants.Where(
                resto => resto.Name.Contains(queryStr) || resto.City.Contains(queryStr) || resto.State.Contains(queryStr)
            ).Select(
                r => new Restaurant(){
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    State = r.State
                }
            ).ToList();
        }


        public async Task<Review> AddAReviewAsync(Review review)
        {
            //this method adds the restoToAdd obj to change tracker
            await _context.AddAsync(review);

            //the "changes" don't get executed until you call the SaveChanges method
            await _context.SaveChangesAsync();

            //this clears the changetracker so it returns to a clean slate
            _context.ChangeTracker.Clear();

            return review;
        }

        public async Task<Review> AddAReview(Review review)
        {
            Review reviewToAdd = new Review(){
                Rating = review.Rating,
                Note = review.Note ?? "",
                RestaurantId = review.RestaurantId
            };
            reviewToAdd = _context.Reviews.Add(reviewToAdd).Entity;
            _context.SaveChanges();

            return new Review() {
                Id = reviewToAdd.Id,
                Rating = reviewToAdd.Rating,
                Note = reviewToAdd.Note
            };
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            //select * from Restaurants in sql query
            //Gets the Entities.Restaurant
            //and we have to convert it to Model.Restaurant
            //.Select() is similar in behavior to .map() is js

            return await _context.Reviews
                .Select(r => r).ToListAsync();

            //same result, in query syntax
            // return (from resto in _context.Restaurants select new Model.Restaurant(){
            //     Id = resto.Id,
            //     Name = resto.Name,
            //     State = resto.State,
            //     City = resto.City
            // }).ToList();
        }

        /// <summary>
        /// returns Model.Restaurant by restaurant Id
        /// </summary>
        /// <param name="id">restuarant Id</param>
        /// <returns>Model.Restaurant</returns>
        public async Task<Restaurant> GetOneRestaurantByIdAsync(int id)
        {
            return await _context.Restaurants
                //this include method joins reviews table with the restaurant table
                //and grabs all reviews that references the selected restaurant
                //by restaurantId
                // .Include("Reviews")
                .AsNoTracking()
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Retrieve a review by review Id
        /// </summary>
        /// <param name="id">review Id</param>
        /// <returns>Review object if there is a match, null if there is none</returns>
        public async Task<Review> GetOneReviewByIdAsync(int id)
        {
            return _context.Reviews
                .AsNoTracking()
                .FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Deletes a restaurant. 
        /// </summary>
        /// <param name="id">id of the restaurant to be deleted</param>
        public async Task RemoveRestaurantAsync(int id)
        {
            _context.Restaurants.Remove(await GetOneRestaurantByIdAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}