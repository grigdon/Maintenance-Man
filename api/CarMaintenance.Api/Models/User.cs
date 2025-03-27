namespace CarMaintenance.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
        // Cars owned by user
        public List<Car>? Cars { get; set; }
        
        // Timestamps
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        // Default Constructor
        public User()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }
        
        // Copy Constructor
        public User(User u)
        {
            Id = Guid.NewGuid();
            Name = u.Name;
            Email = u.Email;
            Password = u.Password;
            Cars = u.Cars;
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }
    }
}