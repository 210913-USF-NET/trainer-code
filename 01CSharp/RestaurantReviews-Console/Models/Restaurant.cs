using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Models
{
    public class Restaurant
    {
        //default empty constructor
        public Restaurant() {
            this.Reviews = new List<Review>();
        }

        //constructor overloading
        public Restaurant(string name) : this()
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
        private string _name;

        //this is an example of property
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                //this pattern means that the string only contains alphanumeric characters, exclamation point, and question mark.
                Regex pattern = new Regex("^[a-zA-Z0-9 !?]+$");

                if(value.Length == 0)
                {
                    throw new InputInvalidException("Restaurant name can't be empty");
                }
                else if(!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Restaurant name can only have alphanumeric characters, !, and ?.");
                }
                else
                {
                    _name = value;
                }
            }
        }

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

        public bool Equals(Restaurant restaurant)
        {
            return this.Name == restaurant.Name && this.City == restaurant.City && this.State == restaurant.State;
        }
    }
}
