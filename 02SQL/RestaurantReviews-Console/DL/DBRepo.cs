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
            throw new NotImplementedException();
        }

        public List<Model.Restaurant> GetAllRestaurants()
        {
            throw new NotImplementedException();
        }

        public Model.Restaurant UpdateRestaurant(Model.Restaurant restaurantToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}