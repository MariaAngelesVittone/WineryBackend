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
                throw new InvalidOperationException("La lista de usuarios está vacía.");
            }

            return users;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ocurrió un error al consultar los usuarios.", ex);
        }
    }

    public void AddUser(UserForCreationDTO userDTO)
    {
        try
        {
            List<User> users = _userRepository.GetUsers();

            if (users.Any(x => x.Username.Equals(userDTO.Username, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new InvalidOperationException("El nombre de usuario ya existe.");
            }

            User newUser = new User
            {
                Id = users.Count != 0 ? users.Max(w => w.Id) + 1 : 1,
                Username = userDTO.Username,
                Password = userDTO.Password,
            };

            _userRepository.AddUser(newUser);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ocurrió un error al agregar el usuario.", ex);
        }
    }
}