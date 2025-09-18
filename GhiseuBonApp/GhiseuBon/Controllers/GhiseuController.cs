using DataAccess.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;


namespace GhiseuBon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GhiseuController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GhiseuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GhiseuModel model)
        {
            await _unitOfWork.Ghiseu.InsertGhiseu(model);
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Edit(int id, [FromBody] GhiseuModel model)
        {
            model.Id = id;
            await _unitOfWork.Ghiseu.UpdateGhiseu(model);
            return Ok();
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

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Ghiseu.DeleteGhiseu(id);
            return Ok();
        }
    }
}
