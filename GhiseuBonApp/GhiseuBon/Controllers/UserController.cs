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
        var user = await _unitOfWork.User.GetByUsernameAsync(loginDto.Username);
        bool isValid = PasswordHasher.VerifyPassword(loginDto.Password, user.PasswordHash);

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
}
