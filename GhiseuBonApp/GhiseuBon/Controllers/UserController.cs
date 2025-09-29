using AutoMapper;
using DataAccess.Models;
using DataAccess.UnitOfWork;
using GhiseuBon.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GhiseuBon.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : CrudControllerBase<UserDto, UserModel, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public UserController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork.User, mapper)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        //StringSanitizer.TrimAllStrings(loginDto, "Password", "PasswordHash");

        var user = await _unitOfWork.User.GetByUsernameAsync(loginDto.Username);
        bool isValid = PasswordHasher.VerifyPassword(loginDto.Password, user.PasswordHash);
        Console.WriteLine($"User:{user.UserName}, isValid:{isValid}");
        if (user == null || !isValid)
        {
            return Unauthorized("Invalid username or password.");
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtTokenGeneration");
        var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim("id", user.Id.ToString()),
                new System.Security.Claims.Claim("username", user.UserName),
                new System.Security.Claims.Claim("role", user.RoleUser)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);


        var userDto = _mapper.Map<UserDto>(user);
        return Ok(new
        {
            token = jwtToken,
            user = userDto
        });
    }
    [HttpPost("register")]
    public async Task<IActionResult> Add([FromBody] RegisterDto dto)
    {
        //StringSanitizer.TrimAllStrings(dto, "Password", "PasswordHash");

        var existingUser = await _unitOfWork.User.GetByUsernameAsync(dto.UserName);
        if (existingUser != null)
        {
            return Conflict("Username already exists.");
        }
        dto.Password = PasswordHasher.HashPassword(dto.Password);
        var userEntity = dto.ToModel();
        await _unitOfWork.User.InsertAsync(userEntity);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtTokenGeneration");
        var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim("id", userEntity.Id.ToString()),
                new System.Security.Claims.Claim("username", userEntity.UserName),
                new System.Security.Claims.Claim("role", userEntity.RoleUser)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
        };
        var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new
        {
            token = jwtToken,
            user = userEntity
        });

    }
}
