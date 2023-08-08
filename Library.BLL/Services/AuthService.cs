
using AutoMapper;
using Library.BLL.DTOs.AuthDto;
using Library.BLL.Exceptions;
using Library.BLL.Interfaces;
using Library.DAL.Models;
using Library.DAL.Models.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _user;
    private readonly SignInManager<User> _signInManager;
    private readonly JWTSettings _options;
    private readonly IMapper _mapper;
    public AuthService(UserManager<User> user, SignInManager<User> signIn, IOptions<JWTSettings> optAccess, IMapper mapper)
    {
        _user = user;
        _signInManager = signIn;
        _options = optAccess.Value;
        _mapper = mapper;
    }
    public string GetToken(User user, IEnumerable<Claim> principal)
    {
        var claims = principal.ToList();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(600)),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task Register(AddUserDto user)
    {
        var mappedUser = _mapper.Map<User>(user);
        var result = await _user.CreateAsync(mappedUser, user.Password);
        if (!result.Succeeded)
        {
            throw new UserAlreadyExistsException("User already exists");
        }
        
        await _signInManager.SignInAsync(mappedUser, isPersistent: false);

        var claim = new Claim(ClaimTypes.Sid, mappedUser.Id.ToString());

        await _user.AddClaimAsync(mappedUser, claim);
    }

    public async Task<string> SignIn(SignInDto user)
    {
        var searchedUser = await _user.FindByEmailAsync(user.Email);
        var result = await _signInManager.PasswordSignInAsync(searchedUser, user.Password, false, false);
        if (!result.Succeeded)
        {

            throw new IncorrectEmailOrPasswordException("Incorrect email or password");
        }

        IEnumerable<Claim> claims = await _user.GetClaimsAsync(searchedUser);
        var mappedUser = _mapper.Map<User>(user);
        var token = GetToken(mappedUser, claims);

        return token;       
    }
}
