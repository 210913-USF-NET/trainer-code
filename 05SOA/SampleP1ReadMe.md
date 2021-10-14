# Store App 2.0
## Overview
Can you imagine that you line up for 1 hour to order a bubble tea as the new normal? The idea of this *Bubble Tea Store App* is to help people save their time to order Bubble Tea online and help the store manager to manage their operation and provide best service to their customers.

It's up on azure: [Link to the app]

## Tech Stack:
* C#
* Entity Framework Core
* ASP.NET MVC
* PostgreSQL DB
* Azure App Services
* Azure DevOps
* Xunit
* Sqlite 
* Moq
* Serilog

## Functionality:
* Add a new customer
* Search customers by name
* Display details of an order
* Place orders to store locations for customers
* View order history of customer
* View order history of location
* View location inventory
* The customer should be able to purchase multiple products
* Order histories should have the option to be sorted by date (latest to oldest and vice versa) or cost (least expensive to most expensive)
* The manager should be able to replenish inventory

## User Stories
* As a customer, I can use my phone number to sign in.
* As a customer, I can check if I already have an existing account when signing up.
* As a customer, I can select a branch location which makes orders to.
* As a customer, I can view a list of available products. 
* As a customer, I can select multiple products and add quantity to a shopping cart. 
* As a customer, I can get notified if I put quantities that are more than in stock.
* As a customer, I can view a shopping cart and go back to shopping.
* As a customer, I can edit or delete items in a shopping cart.
* As a customer, I can get confirmation if my order is placed successfully. 
* As a customer, I can view my order histories with details. 
* As an admin, I can choose a designated branch location.
* As an admin, I can add a new branch location.
* As an admin, I can add a new product.
* As an admin, I can view and select products that have no inventory yet. 
* As an admin, I can add inventory to a specific product.
* As an admin, I can view a list of products that have inventory.
* As an admin, I can replenish inventory to a specific product.

## Additional Features
* Exception Handling
* Input validation
* Logging
* Unit tests
* Use Moq and Sqlite for testing
* DB methods are tested
* Data are persisted
* Use PostgreSQL DB to store data
* Use code first approach to establish a connection to the DB
* WebApp is deployed using Azure App Services
* A CI/CD pipeline is established use Azure Pipelines
* Use ASP.NET MVC for the UI
* DB structure is 3NF
* Have an ER Diagram

{img of ERD}