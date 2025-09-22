using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;


namespace GhiseuBon.Controllers;

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

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> GetById(TKey id)
    {
        await _repository.GetByIdAsync(id);
        return Ok();
    }

    [HttpPost]
    public virtual async Task<IActionResult> Add([FromBody] TEntity entity)
    {
        await _repository.InsertAsync(entity);
        return Ok();
    }

    [HttpPut]
    public virtual async Task<IActionResult> Update([FromBody] TEntity entity)
    {
        await _repository.UpdateAsync(entity);
        return Ok();
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(TKey id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }

}
