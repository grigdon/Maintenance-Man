using CarMaintenance.Api.Enterprise;
using CarMaintenance.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenance.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new UserEC().Users;
        }

        [HttpGet("{id}")]
        public User? GetById(int id)
        {
            return new UserEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public User? DeleteById(int id)
        {
            return new UserEC().DeleteById(id);
        }

        [HttpPost("Search")]
        public List<User> Search([FromBody] Query query)
        {
            return new UserEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<User>();
        }

        [HttpPost]
        public User? AddOrUpdate([FromBody] User? user)
        {
            return new UserEC().AddOrUpdate(user);
        }
    }
}

