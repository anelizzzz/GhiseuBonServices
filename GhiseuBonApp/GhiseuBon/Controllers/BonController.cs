using DataAccess.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace GhiseuBon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonController : CrudControllerBase<BonModel, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BonController(IUnitOfWork unitOfWork) : base(unitOfWork.Bon)
        {
            _unitOfWork = unitOfWork;
        }

        /* [HttpPut]
         public async Task<IActionResult> Add([FromBody] BonModel model)
         {
             await _unitOfWork.Bon.InsertBon(model);
             return Ok();
         }*/

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
