using Data.Entities;

namespace Data.Repositories;

public interface IUserRepository
{
    List<User> GetUsers();
    void AddUser(User user);
}