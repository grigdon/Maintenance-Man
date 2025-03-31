using System.ComponentModel.DataAnnotations;

namespace CarMaintenance.Api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // global user identifier
        
        [StringLength(50)] // fixed length strings; can be reduced if necessary
        public string? Name { get; init; }
        
        [StringLength(50)]
        public string? Email { get; init; }
        
        [StringLength(50)]
        public string? Password { get; init; }
        
        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; }
        
        public virtual IEnumerable<Car>? Cars { get; set; } // downstream navigational property
    }
}