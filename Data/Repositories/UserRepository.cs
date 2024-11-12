using Data.DTO_s;
using Data.Entities;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WineryContext _context;

    public UserRepository(WineryContext context)
    {
        _context = context;
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public User? ValidateUser(CredentialsDTO credentials)
    {
        return _context.Users.FirstOrDefault(p => p.Username == credentials.Username && p.Password == credentials.Password);
    }
}