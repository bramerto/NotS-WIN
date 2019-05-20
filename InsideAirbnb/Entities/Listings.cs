﻿using System;
using System.Collections.Generic;

namespace InsideAirbnb.Entities
{
    public partial class Listings
    {
        public Listings()
        {
            Neighbourhoods = new HashSet<Neighbourhoods>();
            Reviews = new HashSet<Reviews>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int HostId { get; set; }
        public string HostName { get; set; }
        public string NeighbourhoodGroup { get; set; }
        public string Neighbourhood { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }
        public int MinimumNights { get; set; }
        public int NumberOfReviews { get; set; }
        public DateTime? LastReview { get; set; }
        public double? ReviewsPerMonth { get; set; }
        public int CalculatedHostListingsCount { get; set; }
        public int Availability365 { get; set; }

        public virtual ICollection<Neighbourhoods> Neighbourhoods { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
