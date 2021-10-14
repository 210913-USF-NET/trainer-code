using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {
        public Review() { }

        //constructor with restaurantId
        public Review(int restoId)
        {
            this.RestaurantId = restoId;
        }
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        //private field
        private int _rating;
        //property
        [Required]
        [Range(1,5)]
        public int Rating 
        {
            get; set;
            //get
            //{
            //    return _rating;
            //}
            //set
            //{
            //    if(value > 5 || value < 1)
            //    {
            //        throw new InputInvalidException("Rating must be between 1 and 5");
            //    }
            //    else
            //    {
            //        _rating = value;
            //    }
            //}
        }

        public string Note { get; set; }

        public override string ToString()
        {
            return $"Rating: {this.Rating}\nNote: {this.Note}";
        }
    }
}