using CarMaintenance.Api.Database;
using CarMaintenance.Api.Models;

namespace CarMaintenance.Api.Enterprise
{
    // Enterprise controller
    // Acts as a middle-man between the database and the controller
    // Provides readonly data-organizing functions for the controller
    // Makes API calls in the controller simpler
    public class CarEC
    {
        private readonly CarsFakeFileBase _filebase;

        public CarEC()
        {
            _filebase = CarsFakeFileBase.Current;
        }

        public IEnumerable<Car> Cars
        {
            get { return _filebase.Cars.Take(100).Select(c => new Car(c)); }
        }
        
        // search for a car in the list of cars by object member variables in set:= {year, make, model, engine, transmission}
        public IEnumerable<Car> Search(string query)
        {
            string upperQuery = query?.ToUpper() ?? string.Empty;
            
            return _filebase.Cars
                .Where(c => c.Year.ToString().Contains(upperQuery) ||
                                c.Nickname.ToUpper().Contains(upperQuery) ||
                                c.Make.ToUpper().Contains(upperQuery) ||
                                c.Model.ToUpper().Contains(upperQuery) ||
                                c.Trim.ToUpper().Contains(upperQuery) ||
                                c.Engine.ToUpper().Contains(upperQuery) ||
                                c.Transmission.ToUpper().Contains(upperQuery))
                .Select(c => new Car
                {
                    Id = c.Id,
                    Year = c.Year,
                    Nickname = c.Nickname,
                    Make = c.Make,
                    Model = c.Model,
                    Trim = c.Trim,
                    Engine = c.Engine,
                    Transmission = c.Transmission
                })
                .ToList();
        }

        public Car GetById(Guid id)
        {
            var car = _filebase
                .Cars
                .FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                return new Car(car);
            }
            return null;
        }

        public Car? DeleteById(Guid id)
        {
            var car = _filebase.Cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                _filebase.Cars.Remove(car);
                return new Car(car);
            }

            return null;
        }

        public Car? AddOrUpdate(Car? car)
        {
            if (car != null)
            {
                return null;
            }

            return _filebase.AddOrUpdateCar(new Car(car));
        }
    }
}