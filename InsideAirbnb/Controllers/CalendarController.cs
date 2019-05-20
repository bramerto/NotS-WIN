using InsideAirbnb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsideAirbnb.Controllers
{
    public class CalendarController : ControllerBase
    {
        private readonly IRepository<Calendar> _repository;

        public CalendarController(IRepository<Calendar> repository)
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
