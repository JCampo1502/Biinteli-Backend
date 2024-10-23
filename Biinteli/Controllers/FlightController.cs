using App.Dtos.Simple;
using App.Dtos.Standards;
using AutoMapper;
using Bussines.Entities;
using Bussines.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers;

public class FlightController(
    IUnitOfWork UnitOfWork,
    IMapper Mapper,
    ILogger<FlightController> Logger

) : GenericController<Flight, FlightDto, SimpleFlightDto>(UnitOfWork, Mapper, Logger)
{
    protected override IGenericRepository<Flight> GetEntity() => UnitOfWork.Flights;
  

    
}
