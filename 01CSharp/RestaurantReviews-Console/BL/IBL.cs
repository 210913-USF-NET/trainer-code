using Models;
using System.Collections.Generic;
using DL;

namespace RRBL
{
    public interface IBL
    {
        List<Restaurant> GetAllRestaurants();

        Restaurant AddRestaurant(Restaurant resto);
    }
}