using CarMaintenance.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarMaintenance.Api.Database
{
    public class CarsFakeFileBase
    {
        // Makes singleton thread safe
        private static readonly object _lock = new object();
        private static CarsFakeFileBase? _instance;
        private List<Car> _cars;
        
        // Calls private data member
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; }
        }

        // Singleton instance of CarsFakeFileBase 
        public static CarsFakeFileBase Current
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CarsFakeFileBase();
                    }
                    return _instance;
                }
            }
        }
        
        // Where singleton data is stored (private member) with pre-defined objects
        private CarsFakeFileBase()
        {
            _cars = new List<Car>()
            {
                new Car()
                {
                    Id = Guid.NewGuid(),
                    Nickname = "Gabe's Sedan",
                    Year = 2008,
                    Make = "Toyota",
                    Model = "Camry",
                    Trim = "XLE",
                    Engine = "v6",
                    Transmission = "6-speed"
                },
                new Car()
                {
                    Id = Guid.NewGuid(),
                    Nickname = "Dad's Truck",
                    Year = 2006,
                    Make = "Toyota",
                    Model = "Tundra",
                    Trim = "SRS",
                    Engine = "v6",
                    Transmission = "5-speed"
                },
                new Car()
                {
                    Id = Guid.NewGuid(),
                    Nickname = "Mom's SUV",
                    Year = 2015,
                    Make = "Toyota",
                    Model = "Highlander",
                    Trim = "XLE",
                    Engine = "v6",
                    Transmission = "6-speed"
                },
                new Car()
                {
                    Id = Guid.NewGuid(),
                    Nickname = "Tate's SUV",
                    Year = 2004,
                    Make = "Lexus",
                    Model = "LX470",
                    Trim = "UL",
                    Engine = "v8",
                    Transmission = "5-speed"
                }
            };
        }
        
        public Car? AddOrUpdateCar(Car? car)
        {
            if (car == null)
            {
                return null;
            }

            // Check if the car already exists
            var existingCar = _cars.FirstOrDefault(c => c.Id == car.Id);

            if (existingCar == null)
            {
                // If car doesn't exist, assign a new GUID and add to the list
                car.Id = Guid.NewGuid();
                _cars.Add(car);
            }
            else
            {
                // If car exists, update its properties
                int index = _cars.IndexOf(existingCar);
                _cars[index] = car;
            }

            return car;
        }
        
        public Car? GetCarById(Guid id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }
    }
}