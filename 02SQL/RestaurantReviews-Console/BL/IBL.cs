using Models;
using System.Collections.Generic;
using DL;

namespace RRBL
{
    //this is an interface for all business logics i may or may not create
    //interface is a contract, all classes that implements an interface
    //must have the methods listed in the interface
    public interface IBL
    {
        List<Restaurant> GetAllRestaurants();

        Restaurant AddRestaurant(Restaurant resto);

        Restaurant UpdateRestaurant(Restaurant restaurantToUpdate);
    }
}