using System;
namespace Models
{
    public class Review
    {
        //private field
        private int _rating;
        //property
        public int Rating 
        {
            get
            {
                return _rating;
            }
            set
            {
                if(value > 5 || value < 1)
                {
                    throw new Exception("you're wrong");
                }
                else
                {
                    _rating = value;
                }
            }
        }
        public string Note { get; set; }
    }
}