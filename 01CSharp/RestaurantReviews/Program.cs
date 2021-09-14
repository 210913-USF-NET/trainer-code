using System;

namespace RestaurantReviews
{
    //PascalCaseGoesLikeThis
    class Program
    {
        //PascalCases
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Restaurant Reviews!");
            Console.WriteLine("Create a new Restaurant:");

            //constructor, I'm using object's empty constructor
            Restaurant newResto = new Restaurant("New Resto Name", "new city", "new state");
            
            Console.WriteLine(newResto.ToString());

            Console.WriteLine("Name:");

            //camelCases for variables
            newResto.Name = Console.ReadLine();

            Console.WriteLine("City: ");
            newResto.City = Console.ReadLine();

            Console.WriteLine("State: ");
            newResto.State = Console.ReadLine();
            
            Console.WriteLine($"String Interpolation {newResto.ToString()}");
            Console.WriteLine("String arithmetic " + newResto.ToString());
            Console.WriteLine("Another way {0}, {1}, {2}", newResto.Name, newResto.City, newResto.State);
        }
    }

    //this is type of data in CSharp
    class Restaurant
    {
        //default empty constructor
        public Restaurant() {}

        //constructor overloading
        public Restaurant(string name)
        {
            this.Name = name;
        }

        //Constructor chaining
        public Restaurant(string name, string city, string state) : this(name)
        {
            this.City = city;
            this.State = state;
        }

        //this is type member
        //this is an example of property
        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        // //this is field
        // private string _name;

        // //this is a wrapper for the field above
        // public string GetName()
        // {
        //     return _name;
        // }

        // public void SetName(string value)
        // {
        //     _name = value;
        // }

        public override string ToString()
        {
            return $"Name: {this.Name}, City: {this.City}, State: {this.State}";
        }
    }
}
