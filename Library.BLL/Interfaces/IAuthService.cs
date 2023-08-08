
using Library.BLL.DTOs.AuthDto;
using Library.DAL.Models;
using System.Security.Claims;

namespace Library.BLL.Interfaces;

public interface IAuthService
{
    string GetToken(User user, IEnumerable<Claim> principal);
    Task Register(AddUserDto user);
    Task<string> SignIn(SignInDto user);

}
