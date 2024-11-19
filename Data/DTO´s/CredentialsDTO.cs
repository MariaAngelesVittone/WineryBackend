using System.ComponentModel.DataAnnotations;

namespace Data.DTO_s;

public class CredentialsDTO
{
    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Username is required.")]
    public string Password { get; set; } = string.Empty;
}