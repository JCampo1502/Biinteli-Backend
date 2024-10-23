using AutoMapper;
using Bussines.Entities;
using Bussines.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public abstract class GenericController<T, TDto, TSimpleDto> : BaseApiController
    where T : BaseEntity
    where TDto : IGenericDto
    where TSimpleDto : class
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }
    protected ILogger<GenericController<T, TDto, TSimpleDto>> Logger { get; }

    protected GenericController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GenericController<T, TDto, TSimpleDto>> logger)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        Logger = logger;
    }

    protected abstract IGenericRepository<T> GetEntity();

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TDto>> GetById(string id)
    {
        try
        {
            var record = await GetEntity().FindFirstAsync(x => x.Id == id);
            if (record == null) return NotFound();

            return Ok(Mapper.Map<TDto>(record));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error retrieving entity by id.");
            return StatusCode(500, "Something went wrong.");
        }
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<List<TDto>>> GetAll()
    {
        try
        {
            var records = await GetEntity().GetAllAsync();

            if (records == null || !records.Any())
                return NoContent();

            var mappedRecords = Mapper.Map<List<TDto>>(records);
            return Ok(mappedRecords);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error retrieving all entities.");
            return StatusCode(500, "Something went wrong.");
        }
    }

    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TDto>> Post([FromForm] TSimpleDto dto)
    {
        try
        {
            if (dto == null) return BadRequest("Invalid DTO.");

            var newEntity = Mapper.Map<T>(Mapper.Map<TDto>(dto));
            newEntity.Id = Guid.NewGuid().ToString();
            await GetEntity().AddAsync(newEntity);
            await UnitOfWork.SaveAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = newEntity.Id }, dto);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error adding new entity.");
            return StatusCode(500, "Something went wrong.");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var entity = await GetEntity().FindFirstAsync(e => e.Id == id);
            if (entity == null) return NotFound();

            GetEntity().Remove(entity);
            await UnitOfWork.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error deleting entity.");
            return StatusCode(500, "Something went wrong.");
        }
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update( [FromForm] TDto dto)
    {
        try
        {
            if (dto == null) return BadRequest("Invalid DTO.");

            var entity = Mapper.Map<T>(dto);            

            GetEntity().Update(entity);
            await UnitOfWork.SaveAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error updating entity.");
            return StatusCode(500, "Something went wrong.");
        }
    }
}
