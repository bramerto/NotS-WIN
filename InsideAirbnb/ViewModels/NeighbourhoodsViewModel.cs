using InsideAirbnb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.ViewModels
{
    public class NeighbourhoodsViewModel
    {
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public virtual Listings Listing { get; set; }
    }
}
