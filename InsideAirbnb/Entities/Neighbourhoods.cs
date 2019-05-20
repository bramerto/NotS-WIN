using System;
using System.Collections.Generic;

namespace InsideAirbnb.Entities
{
    public partial class Neighbourhoods
    {
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public virtual Listings Listing { get; set; }
    }
}
