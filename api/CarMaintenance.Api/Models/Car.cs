using System.Runtime.InteropServices;

namespace CarMaintenance.Api.Models
{
    public class Car
    {
        public Guid Id { get; set; } = new Guid();
        public Guid UserId { get; set; }
        public string? Nickname { get; set; }
        public int Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Trim { get; set; }
        public string? Engine { get; set; }
        public string? Transmission { get; set; }
        
        // Maintenance items for car
        public List<MaintenanceItem>? MaintenanceItems { get; set; }
        public Car() { }
        public Car(Car c)
        {
            Id = c.Id;
            UserId = c.UserId;
            Nickname = c.Nickname;
            Year = c.Year;
            Make = c.Make;
            Model = c.Model;
            Trim = c.Trim;
            Engine = c.Engine;
            Transmission = c.Transmission;
            MaintenanceItems = c.MaintenanceItems;
        }
    }
}

