using System;
using Models;
using System.Collections.Generic;
using DL;

namespace RRBL
{
    public class BL : IBL
    {
        private IRepo _repo;
        
        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _repo.GetAllRestaurants();
        }

        public Restaurant AddRestaurant(Restaurant resto)
        {
            return _repo.AddRestaurant(resto);
        }
    }
}
