/*
Given Restaurants and Reviews Table,
Write a query that will get us

- the 2 reviews with highest rating of a restaurant 
that contains the word "salt" with following columns, 
Restaurant Name, Rating, Note

- Average rating of each restaurant with following columns, 
Restaurant Name, Average Rating and list them by 
their restaurant name in descending order

- The number of reviews from each restaurant that has rating 4 or higher
*/

Select top 2 Reviews.Rating, Reviews.Note, Restaurants.Name from Reviews 
join Restaurants on Reviews.RestaurantId = Restaurants.Id
where Restaurants.Name like '%salt%'
order by Reviews.Rating desc;

Select Restaurants.Name, AVG(Reviews.Rating) as 'Average Rating' FROM
Reviews join Restaurants on Reviews.RestaurantId = Restaurants.Id
group by Restaurants.Name
order by Restaurants.Name asc;

Select Count(Reviews.Rating), Restaurants.Name from
Reviews join Restaurants on Reviews.RestaurantId = Restaurants.Id
where Reviews.Rating > 3
group by Restaurants.Name