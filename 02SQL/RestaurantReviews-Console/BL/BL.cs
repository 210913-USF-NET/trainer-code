using System;
using Models;
using System.Collections.Generic;
using DL;

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

        public Restaurant AddRestaurant(Restaurant resto)
        {
            return _repo.AddRestaurant(resto);
        }

        public Restaurant UpdateRestaurant(Restaurant restoToUpdate)
        {
            //add logic to update restaurant
            return _repo.UpdateRestaurant(restoToUpdate);
        }
    }
}
