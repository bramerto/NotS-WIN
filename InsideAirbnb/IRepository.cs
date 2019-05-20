using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb
{
    public interface IRepository<T>
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
    }
}
