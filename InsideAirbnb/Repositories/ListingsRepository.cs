using InsideAirbnb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Repositories
{
    public class ListingsRepository : IRepository<Listings>
    {
        private readonly inside_airbnbContext _context;

        public ListingsRepository(inside_airbnbContext context)
        {
            _context = context;
        }

        public Listings GetById(int Id)
        {
            return _context.Listings.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Listings> GetAll()
        {
            return _context.Listings.ToList();
        }
    }
}
