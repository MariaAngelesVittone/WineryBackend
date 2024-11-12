using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Data.DTO_s;

public class UserForCreationDTO
{
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "El nombre de usuario debe contener al menos una letra mayúscula y un número")]
    [DefaultValue("string")]
    public required string Username { get; set; }
    [StringLength(12, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 12 caracteres.")]
    public required string Password { get; set; }
}