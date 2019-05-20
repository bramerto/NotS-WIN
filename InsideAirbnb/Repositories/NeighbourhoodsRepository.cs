using InsideAirbnb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Repositories
{
    public class NeighbourhoodsRepository : IRepository<Neighbourhoods>
    {
        private readonly inside_airbnbContext _context;

        public NeighbourhoodsRepository(inside_airbnbContext context)
        {
            _context = context;
        }

        public Neighbourhoods GetById(int Id)
        {
            return _context.Neighbourhoods.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Neighbourhoods> GetAll()
        {
            return _context.Neighbourhoods.ToList();
        }
    }
}
