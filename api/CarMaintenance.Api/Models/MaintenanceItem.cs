namespace CarMaintenance.Api.Models
{
    public class MaintenanceItem
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public Decimal Cost { get; set; }
        
        // Timestamps
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public MaintenanceItem()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }

        public MaintenanceItem(MaintenanceItem m)
        {
            Id = Guid.NewGuid();
            CarId = m.CarId;
            Car = m.Car;
            Description = m.Description;
            Date = m.Date;
            Cost = m.Cost;
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }
    }
}

