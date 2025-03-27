namespace CarMaintenance.Api.Models
{
    public class MaintenanceItem
    {
        public Guid Id { get; set; } = new Guid();
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public Decimal Cost { get; set; }
        
        public MaintenanceItem() { }

        public MaintenanceItem(MaintenanceItem m)
        {
            Id = m.Id;
            CarId = m.CarId;
            Car = m.Car;
            Description = m.Description;
            Date = m.Date;
            Cost = m.Cost;
        }
    }
}

