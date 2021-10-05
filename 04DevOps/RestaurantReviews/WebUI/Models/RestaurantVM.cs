using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
{
    public class RestaurantVM
    {
        //constructor
        public RestaurantVM() { }

        public RestaurantVM(Restaurant resto)
        {
            this.Id = resto.Id;
            this.Name = resto.Name;
            this.City = resto.City;
            this.State = resto.State;
            this.Reviews = resto.Reviews;
        }
        public int Id { get; set; }

        [Display(Name = "Restaurant Name")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Restaurant name can only have alphanumeric characters, !, and ?.")]
        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public double Rating { get; set; }

        public List<Review> Reviews { get; set; }

        public Restaurant ToModel()
        {
            Restaurant newResto;
            try
            {
                newResto = new Restaurant
                {
                    Id = this.Id,
                    Name = this.Name ?? "",
                    City = this.City,
                    State = this.State
                };

                //ternary 
                // IfStatement ? ifTrue : ifFalse
                // null checker
                // ifExists/notNull ?? ifFalse
                // IsNull?.Prperty
            }
            catch
            {
                throw;
            }
            return newResto;
        }
    }
}
