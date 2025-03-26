namespace CarMaintenance.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public User() { }
        public User(User u)
        {
            Id = u.Id;
            Name = u.Name;
            Email = u.Email;
            Password = u.Password;
        }
    }
}

