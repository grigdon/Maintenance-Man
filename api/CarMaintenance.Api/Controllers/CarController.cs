using Microsoft.AspNetCore.Mvc;
using CarMaintenance.Api.Models;
using CarMaintenance.Api.Enterprise;

namespace CarMaintenance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return new CarEC().Cars;
        }

        [HttpGet("{id}")]
        public Car? GetById(int id)
        {
            return new CarEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public Car? DeleteById(int id)
        {
            return new CarEC().DeleteById(id);
        }

        [HttpPost("Search")]
        public List<Car> Search([FromBody] Query query)
        {
            return new CarEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<Car>();
        }

        [HttpPost]
        public Car? AddOrUpdate([FromBody] Car? car)
        {
            return new CarEC().AddOrUpdate(car);
        }
    }
}
