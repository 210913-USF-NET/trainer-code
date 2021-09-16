using System;
using System.Collections.Generic;

namespace Models
{
    public class Restaurant
    {
        //default empty constructor
        public Restaurant() {
            this.Reviews = new List<Review>();
        }

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

        public List<Review> Reviews { get; set; }

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
