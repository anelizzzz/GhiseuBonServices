using AutoMapper;
using DataAccess.Models;
using DataAccess.UnitOfWork;
using GhiseuBon.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GhiseuBon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GhiseuController : CrudControllerBase<GhiseuDto, GhiseuModel, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GhiseuController(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork.Ghiseu, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> MarkAsActive(int id)
        {
            await _unitOfWork.Ghiseu.MarkAsActive(id);
            return Ok();
        }

        [HttpPut("{id}/deactivate")]
        public async Task<IActionResult> MarkAsInactive(int id)
        {
            await _unitOfWork.Ghiseu.MarkAsInactive(id);
            return Ok();
        }
    }
}
