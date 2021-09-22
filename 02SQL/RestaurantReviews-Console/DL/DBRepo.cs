using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = DL.Entities;

namespace DL
{
    public class DBRepo : IRepo
    {
        private Entity.RestaurantDBContext _context;
        public DBRepo(Entity.RestaurantDBContext context)
        {
            _context = context;
        }
        public Model.Restaurant AddRestaurant(Model.Restaurant resto)
        {
            Entity.Restaurant restoToAdd = new Entity.Restaurant(){
                Name = resto.Name,
                City = resto.City ?? "",
                State = resto.State ?? ""
            };
            
            //this method adds the restoToAdd obj to change tracker
            restoToAdd = _context.Add(restoToAdd).Entity;

            //the "changes" don't get executed until you call the SaveChanges method
            _context.SaveChanges();

            //this clears the changetracker so it returns to a clean slate
            _context.ChangeTracker.Clear();

            return new Model.Restaurant()
            {
                Id = restoToAdd.Id,
                Name = restoToAdd.Name,
                City = restoToAdd.City,
                State = restoToAdd.State
            };
        }

        public List<Model.Restaurant> GetAllRestaurants()
        {
            //select * from Restaurants in sql query
            //Gets the Entities.Restaurant
            //and we have to convert it to Model.Restaurant
            //.Select() is similar in behavior to .map() is js
            return _context.Restaurants.Select(
                restaurant => new Model.Restaurant() {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    State = restaurant.State,
                    City = restaurant.City
                }
            ).ToList();
        }

        public Model.Restaurant UpdateRestaurant(Model.Restaurant restaurantToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}