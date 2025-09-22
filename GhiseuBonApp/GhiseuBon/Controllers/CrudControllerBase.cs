using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace GhiseuBon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudControllerBase<TEntity, TKey> : ControllerBase
        where TEntity : class
    {
        protected readonly IGenericRepository<TEntity, TKey> _repository;
        public CrudControllerBase(IGenericRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                if (items == null || !items.Any())
                    return NotFound("No items found.");
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving items: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(TKey id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item == null)
                    return NotFound($"Item with id {id} not found.");
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving item: {ex.Message}");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] TEntity entity)
        {
            try
            {
                await _repository.InsertAsync(entity);
                return Ok("Item added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding item: {ex.Message}");
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TEntity entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
                return Ok("Item updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating item: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return Ok("Item deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting item: {ex.Message}");
            }
        }
    }
}
