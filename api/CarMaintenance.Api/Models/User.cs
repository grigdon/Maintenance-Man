namespace CarMaintenance.Api.Models
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
        // Cars owned by user
        public List<Car>? Cars { get; set; }

        public User() { }
        public User(User u)
        {
            Id = u.Id;
            Name = u.Name;
            Email = u.Email;
            Password = u.Password;
            Cars = u.Cars;
        }
    }
}

