using Microsoft.AspNetCore.Mvc;
using CarMaintenance.Api.Models;

namespace CarMaintenance.Api.Controllers
{
    
[ApiController]
[Route("controller")]
public class CarController
{  
    private readonly ILogger<CarController> _logger;

    public CarController(ILogger<CarController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Car> Get()
    {
        return new Car().Cars;
    }

    [HttpGet("{id}")]
    public PatientDTO? GetById(int id)
    {
        return new PatientEC().GetById(id);
    }

    [HttpDelete("{id}")]
    public PatientDTO? DeleteByID(int id)
    {
        return new PatientEC().DeleteById(id);
    }
    [HttpPost("Search")]
    public List<PatientDTO> Search([FromBody] Query query)
    {
        return new PatientEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<PatientDTO>();
    }
    [HttpPost]
    public Patient? AddOrUpdate([FromBody] PatientDTO? patient)
    {
        return new PatientEC().AddOrUpdate(patient);
    }
    
}
}
