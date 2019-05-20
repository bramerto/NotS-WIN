using InsideAirbnb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsideAirbnb.Controllers
{
    public class ReviewsController : ControllerBase
    {
        private readonly IRepository<Reviews> _repository;

        public ReviewsController(IRepository<Reviews> repository)
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
