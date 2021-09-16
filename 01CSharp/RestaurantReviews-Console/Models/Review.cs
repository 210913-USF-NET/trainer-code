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
                    throw new InputInvalidException("Rating must be between 1 and 5");
                }
                else
                {
                    _rating = value;
                }
            }
        }
        public string Note { get; set; }

        public override string ToString()
        {
            return $"Rating: {this.Rating}\nNote: {this.Note}";
        }
    }
}