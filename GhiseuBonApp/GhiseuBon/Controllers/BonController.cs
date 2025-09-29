using AutoMapper;
using DataAccess.Models;
using DataAccess.UnitOfWork;
using GhiseuBon.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GhiseuBon.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BonController : CrudControllerBase<BonDto, BonModel, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BonController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork.Bon, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPut("{id}/progress")]
        public async Task<IActionResult> MarkAsInProgress(int id)
        {
            await _unitOfWork.Bon.MarkAsInProgress(id);
            return Ok();
        }

        [HttpPut("{id}/received")]
        public async Task<IActionResult> MarkAsReceived(int id)
        {
            await _unitOfWork.Bon.MarkAsReceived(id);
            return Ok();
        }
        [HttpPut("{id}/closed")]
        public async Task<IActionResult> MarkAsClosed(int id)
        {
            await _unitOfWork.Bon.MarkAsClosed(id);
            return Ok();
        }

    }
}
