namespace CarMaintenance.Api.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Engine { get; set; }
        public string? Transmission { get; set; }

        public Car() { }
        public Car(Car c)
        {
            Id = c.Id;
            Year = c.Year;
            Make = c.Make;
            Model = c.Model;
            Engine = c.Engine;
            Transmission = c.Transmission;
        }
    }
}

