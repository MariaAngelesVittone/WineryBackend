using System.ComponentModel.DataAnnotations;

namespace Data.DTO_s;

public class CredentialsDTO
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}