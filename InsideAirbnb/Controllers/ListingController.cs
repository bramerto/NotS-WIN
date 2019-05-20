using InsideAirbnb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsideAirbnb.Controllers
{
    public class ListingsController : ControllerBase
    {
        private readonly IRepository<Listings> _repository;

        public ListingsController(IRepository<Listings> repository)
        {
            _repository = repository;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_repository.GetById(Id));
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

    }
}
