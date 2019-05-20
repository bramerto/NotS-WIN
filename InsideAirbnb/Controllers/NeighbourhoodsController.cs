using InsideAirbnb.Entities;
using InsideAirbnb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsideAirbnb.Controllers
{
    public class NeighbourhoodsController : Controller
    {
        private readonly IRepository<Neighbourhoods> _repository;

        public NeighbourhoodsController(IRepository<Neighbourhoods> repository)
        {
            _repository = repository;
        }

        [Authorize]
        public IActionResult Get(int Id)
        {
            var neigbourhood = _repository.GetById(Id);

            var viewmodel = new NeighbourhoodsViewModel()
            {
                Id = neigbourhood.Id
            };

            return View(viewmodel);
        }

        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

    }
}
