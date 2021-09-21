/*
DDL: data defn language
*/
DROP TABLE Reviews;
DROP TABLE Restaurants;

CREATE TABLE Restaurants(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    City VARCHAR(50),
    State VARCHAR(50)
);

/*Alter to change column data type, add new column, delete column..*/
/*Drop to get rid of the table COMPLETELY*/
/*Truncate to keep the table structure but get rid of all the data inside*/

CREATE TABLE Reviews(
    Id INT PRIMARY KEY IDENTITY,
    Rating INT CHECK(Rating >= 0 and Rating <= 5) NOT NULL,
    Note TEXT,
    RestaurantId INT FOREIGN KEY REFERENCES Restaurants(Id) ON DELETE CASCADE NOT NULL
);

/*
DML: Data Manipulation Language
*/

INSERT INTO Restaurants (Name, City, State) values
('Salt and Straw', 'Portland', 'OR'),
('Daebak Wang Mandu', 'Seattle', 'WA'),
('McDonald''s', 'Denver', 'CO'),
('Costco', 'Houston', 'TX'),
('Claim Jumpers', 'Tukwila', 'WA');

Select * From Restaurants;

INSERT INTO Reviews (Rating, Note, RestaurantId) VALUES
(5, 'Have you ever been to costco food courts?', 4),
(5, 'cheap hotdogs', 4),
(0, 'I wasn''t lovin'' it', 3),
(4, 'Portion size too big but the food is delicious', 5);

Select * From Reviews;