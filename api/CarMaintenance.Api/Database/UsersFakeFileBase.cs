using CarMaintenance.Api.Models;

namespace CarMaintenance.Api.Database;

public class UsersFakeFileBase
{
    private static object _lock = new object();

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

    private static UsersFakeFileBase? _instance;

    private UsersFakeFileBase()
    {
        _instance = null;
        List<User> users = new List<User>()
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
}