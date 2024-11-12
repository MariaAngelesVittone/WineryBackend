using Data.Entities;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    public List<User> GetUsers()
    {
        return users;
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public static List<User> users = new List<User>
    {
    new User
    {
    Id = 1,
    Username = "angie1@gmail.com",
    Password = "12345678",
    }
    };
}