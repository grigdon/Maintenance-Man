using CarMaintenance.Api.Database;
using CarMaintenance.Api.Models;

namespace CarMaintenance.Api.Enterprise
{
    // Enterprise controller
    // Acts as a middle-man between the database and the controller
    // Provides readonly data-organizing functions for the controller
    // Makes API calls in the controller simpler
    public class UserEC
    {
        private readonly UsersFakeFileBase _filebase;

        public UserEC()
        {
            _filebase = UsersFakeFileBase.Current;
        }

        public IEnumerable<User> Users
        {
            get { return _filebase.Users.Take(100).Select(u => new User(u)); }
        }

        // search for a user in the list of users by object member variables in set:= {name}
        public IEnumerable<User> Search(string query)
        {
            string upperQuery = query?.ToUpper() ?? string.Empty;

            return _filebase.Users
                .Where(u => u.Name.ToUpper().Contains(upperQuery))
                .Select(u => new User()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Password = u.Password
                })
                .ToList();
        }

        public User GetById(Guid id)
        {
            var user = _filebase
                .Users
                .FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return new User(user);
            }

            return null;
        }

        public User? DeleteById(Guid id)
        {
            var user = _filebase.Users.FirstOrDefault(c => c.Id == id);
            if (user != null)
            {
                _filebase.Users.Remove(user);
                return new User(user);
            }

            return null;
        }

        public User? AddOrUpdate(User? user)
        {
            if (user != null)
            {
                return null;
            }

            return _filebase.AddOrUpdateUser(new User(user));
        }
    }
}

