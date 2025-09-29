using AutoMapper;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace GhiseuBon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudControllerBase<TDto, TEntity, TKey> : ControllerBase
        where TEntity : class
        where TDto : class
    {
        protected readonly IGenericRepository<TEntity, TKey> _repository;
        protected readonly IMapper _mapper;
        public CrudControllerBase(IGenericRepository<TEntity, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<TDto>>(entities));
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> GetById(TKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(_mapper.Map<TDto>(entity));
        }
        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.InsertAsync(entity);
            return Ok("Item added successfully.");
        }
        //[Authorize]
        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(entity);
            return Ok("Item updated successfully.");
        }
        //[Authorize]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            await _repository.DeleteAsync(id);
            return Ok("Item deleted successfully.");
        }

    }
}
