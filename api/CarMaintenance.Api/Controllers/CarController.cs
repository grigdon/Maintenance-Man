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
        private readonly CarEC _carEC;

        // Dependency injection
        public CarController(ILogger<CarController> logger, CarEC carEc)
        {
            _logger = logger;
            _carEC = carEc;
        }
        
        // Create car
        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            var createdCar = await _carEC.CreateCarAsync(car);
            return CreatedAtAction(nameof(GetCarByCarId), new { id = createdCar.Id }, createdCar);
        }
        
        // Read list of cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _carEC.GetCarsAsync();
            return Ok(cars);
        }
        
        // Read car by carId
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Car>> GetCarByCarId(Guid id)
        {
            var car = await _carEC.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        
        // Read car by userId (using a distinct route)
        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<Car>> GetCarByUserId(Guid userId)
        {
            var car = await _carEC.GetCarByUserIdAsync(userId);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        
        // Update car 
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Car>> UpdateCarById(Guid id, [FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            var updatedCar = await _carEC.UpdateCarAsync(id, car);
            if (updatedCar == null)
            {
                return NotFound();
            }
            return Ok(updatedCar);
        }
        
        // Delete car by carId
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteByCarId(Guid id)
        {
            var result = await _carEC.DeleteCarAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}