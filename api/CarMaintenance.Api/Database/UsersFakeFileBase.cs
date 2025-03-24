using CarMaintenance.Api.Models;

namespace CarMaintenance.Api.Database
{
    public class UsersFakeFileBase
    {
        private static object _lock = new object();
        private static UsersFakeFileBase? _instance;
        private List<User> _users;
        
        // calls private data member
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
                }
    
                return _instance;
            }
        }
    
        private UsersFakeFileBase()
        {
            _users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "Gabe Rigdon",
                    Email = "gabe@email.com",
                    Password = "secure_password_here",
                },
                new User()
                {
                    Id = 2,
                    Name = "Joab Temotio",
                    Email = "joab@email.com",
                    Password = "secure_password_here",
                },
                new User()
                {
                    Id = 3,
                    Name = "Jack Hyland",
                    Email = "jack@email.com",
                    Password = "secure_password_here",
                },
            };
        }
        
        // Tracks the greatest Id in the list of Users
        private int LastKey
        {
            get
            {
                if (Users.Any())
                {
                    return Users.Select(u => u.Id).Max();
                }
                return 0;
            }
        }
        
        public User? AddOrUpdateUser(User? user)
        {
            if (user == null)
            {
                return null;
            }
    
            bool isAdd = false;
            if (user.Id <= 0)
            {
                user.Id = LastKey + 1;
                isAdd = true;
            }
    
            if (isAdd)
            {
                Users.Add(user);
            }
    
            return user;
        }
    }

}



      
   