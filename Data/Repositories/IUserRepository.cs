using Data.DTO_s;
using Data.Entities;

namespace Data.Repositories;

public interface IUserRepository
{
    List<User> GetUsers();
    void AddUser(User user);
    User? ValidateUser(CredentialsDTO credentials);
}