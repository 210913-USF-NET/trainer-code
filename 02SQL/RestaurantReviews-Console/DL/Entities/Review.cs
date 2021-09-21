using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Note { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
