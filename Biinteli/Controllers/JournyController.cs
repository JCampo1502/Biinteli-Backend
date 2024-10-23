using App.Dtos.Simple;
using App.Dtos.Standards;
using AutoMapper;
using Bussines.Entities;
using Bussines.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class JourneyController(
    IUnitOfWork UnitOfWork,
    IMapper Mapper,
    ILogger<JourneyController> Logger
) : GenericController<Journey, JourneyDto, SimpleJourneyDto>(UnitOfWork, Mapper, Logger)
{
    protected override IGenericRepository<Journey> GetEntity() => UnitOfWork.Journeys;

    [HttpGet("FilterByOriginAndDestination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<JourneyDto>> FilterByOriginAndDestination(
        [FromQuery] string origin, 
        [FromQuery] string destination
    ) {
        try
        {
            var record = await UnitOfWork.Journeys.FilterByOriginAndDestination(origin, destination);
            if (record == null) return NotFound();

            return Ok(Mapper.Map<List<JourneyDto>>(record));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error retrieving entity by id.");
            return StatusCode(500, "Something went wrong.");
        }
    }
}
