using CarMaintenance.Api.Models;

// this class uses a singleton pattern for storing car objects in a list of type List<Car> 

namespace CarMaintenance.Api.Database
{
    public class CarsFakeFileBase
    {
        // makes singleton thread safe
        private static object _lock = new object();
        private static CarsFakeFileBase? _instance;
        private List<Car> _cars;
        
        // calls private data member
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; }
        }

        // singleton instance of CarsFakeFileBase 
        public static CarsFakeFileBase Current
        {
            get
            {
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new CarsFakeFileBase();
                    }
                }
                return _instance;
            }
        }
        
        // where singleton data is stored (private member) with pre-defined objects
        private CarsFakeFileBase()
        {
            _cars = new List<Car>()
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
                },
                new Car()
                {
                    Id = 3,
                    Year = 2015,
                    Make = "Toyota",
                    Model = "Highlander",
                    Engine = "v6",
                    Transmission = "6-speed"
                },
                new Car()
                {
                    Id = 4,
                    Year = 2004,
                    Make = "Make",
                    Model = "LX470",
                    Engine = "v8",
                    Transmission = "5-speed"
                }
            };
        }
        
        // Tracks the greatest Id in the list of Cars
        private int LastKey
        {
            get
            {
                if (Cars.Any())
                {
                    return Cars.Select(c => c.Id).Max();
                }
                return 0;
            }
        }
        
        public Car? AddOrUpdateCar(Car? car)
        {
            if (car == null)
            {
                return null;
            }

            bool isAdd = false;
            if (car.Id <= 0)
            {
                car.Id = LastKey + 1;
                isAdd = true;
            }

            if (isAdd)
            {
                Cars.Add(car);
            }

            return car;
        }
    }
}
        