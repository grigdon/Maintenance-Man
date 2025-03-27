namespace CarMaintenance.Api.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Nickname { get; set; }
        public int Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Trim { get; set; }
        public string? Engine { get; set; }
        public string? Transmission { get; set; }
        
        // Timestamps
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        
        // Maintenance items for car
        public List<MaintenanceItem>? MaintenanceItems { get; set; }

        // Default constructor
        public Car()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }
        
        // Copy constructor
        public Car(Car c)
        {
            Id = Guid.NewGuid();
            UserId = c.UserId;
            Nickname = c.Nickname;
            Year = c.Year;
            Make = c.Make;
            Model = c.Model;
            Trim = c.Trim;
            Engine = c.Engine;
            Transmission = c.Transmission;
            CreatedOn = c.CreatedOn;
            ModifiedOn = c.ModifiedOn;
            MaintenanceItems = c.MaintenanceItems?.Select(i =>
                new MaintenanceItem(i) { CarId = this.Id }).ToList();
        }
    }
}