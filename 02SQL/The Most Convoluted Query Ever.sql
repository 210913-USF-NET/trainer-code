select Count(Reviews.Id) as numRatings, Reviews.Rating, Restaurants.Name
from Reviews
join Restaurants
on Reviews.RestaurantId = Restaurants.Id
where RestaurantId = (select Id from Restaurants where Name like '%straw%')
group by Rating, Restaurants.Name
having Count(Reviews.Id) > 1

-- union all

-- select Count(Reviews.Id) as numRatings, Reviews.Rating, Restaurants.Name 
-- from Reviews join Restaurants
-- on Reviews.RestaurantId = Restaurants.Id
-- group by Rating, Restaurants.Name
-- order by Rating desc;