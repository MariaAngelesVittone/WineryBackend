using Data.DTO_s;
using Data.Entities;

namespace Common.Services;

public interface IUserService
{
    List<User> GetUsers();
    void AddUser(UserForCreationDTO userDTO);
}