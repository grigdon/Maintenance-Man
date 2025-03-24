using CarMaintenance.Api.Models;

namespace CarMaintenance.Api.Database
{
    public class CarsFakeFileBase
    {
        private static object _lock = new object();

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
                }

                return _instance;
            }
        }

        private static CarsFakeFileBase? _instance;

        private CarsFakeFileBase()
        {
            _instance = null;
            List<Car> cars = new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Year = 2008,
                    Make = "Toyota",
                    Model = "Camry",
                    Engine = "v6",
                    Transmission = "6-speed"
                },
                new Car()
                {
                    Id = 2,
                    Year = 2006,
                    Make = "Toyota",
                    Model = "Tundra",
                    Engine = "v6",
                    Transmission = "5-speed"
                }
            };
        }
    }
};

