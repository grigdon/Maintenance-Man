using CarMaintenance.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarMaintenance.Api.Database
{
    public class UsersFakeFileBase
    {
        private static readonly object _lock = new object();
        private static UsersFakeFileBase? _instance;
        private List<User> _users;
        
        // Calls private data member
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
    
        public static UsersFakeFileBase Current
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UsersFakeFileBase();
                    }
                    return _instance;
                }
            }
        }
    
        private UsersFakeFileBase()
        {
            _users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Gabe Rigdon",
                    Email = "gabe@email.com",
                    Password = "secure*password_here",
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Joab Temotio",
                    Email = "joab@email.com",
                    Password = "secure_password_here",
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Jack Hyland",
                    Email = "jack@email.com",
                    Password = "secure_password_here",
                },
            };
        }
        
        public User? AddOrUpdateUser(User? user)
        {
            if (user == null)
            {
                return null;
            }

            // Check if the user already exists
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser == null)
            {
                // If user doesn't exist, assign a new GUID and add to the list
                user.Id = Guid.NewGuid();
                _users.Add(user);
            }
            else
            {
                // If user exists, update its properties
                int index = _users.IndexOf(existingUser);
                _users[index] = user;
            }

            return user;
        }
        
        public User? GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}