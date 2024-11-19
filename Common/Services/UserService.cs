using Data.DTO_s;
using Data.Entities;
using Data.Repositories;

namespace Common.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetUsers()
    {
        try
        {
            var users = _userRepository.GetUsers();

            if (users.Count == 0)
            {
                throw new InvalidOperationException("The user list is empty.");
            }

            return users;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while fetching the users.", ex);
        }
    }

    public void AddUser(UserForCreationDTO userDTO)
    {
        try
        {
            List<User> users = _userRepository.GetUsers();

            if (users.Any(x => x.Username.Equals(userDTO.Username, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new InvalidOperationException("The username already exists.");
            }

            User newUser = new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
            };

            _userRepository.AddUser(newUser);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while adding the user.", ex);
        }
    }
}