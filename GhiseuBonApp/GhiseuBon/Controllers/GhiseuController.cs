using DataAccess.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace GhiseuBon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GhiseuController : CrudControllerBase<GhiseuModel, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GhiseuController(IUnitOfWork unitOfWork)
            : base(unitOfWork.Ghiseu)
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
