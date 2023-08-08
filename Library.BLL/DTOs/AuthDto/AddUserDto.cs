using System.ComponentModel.DataAnnotations;

namespace Library.BLL.DTOs.AuthDto;

public class AddUserDto
{
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
