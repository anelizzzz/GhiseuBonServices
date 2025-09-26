using AutoMapper;
using DataAccess.Models;
using DataAccess.UnitOfWork;
using GhiseuBon.Dtos;
using Microsoft.AspNetCore.Mvc;

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

}
