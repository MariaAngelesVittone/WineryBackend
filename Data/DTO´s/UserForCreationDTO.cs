using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Data.DTO_s;

public class UserForCreationDTO
{
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "The username must contain at least one uppercase letter and one number.")]
    [DefaultValue("string")]
    public required string Username { get; set; }
    [StringLength(100, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long.")]
    public required string Password { get; set; }
}