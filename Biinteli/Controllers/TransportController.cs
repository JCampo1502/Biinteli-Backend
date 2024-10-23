using App.Dtos.Simple;
using App.Dtos.Standards;
using AutoMapper;
using Bussines.Entities;
using Bussines.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;


public class TransportController(
    IUnitOfWork UnitOfWork,
    IMapper Mapper,
    ILogger<TransportController> Logger
) : GenericController<Transport, TransportDto, SimpleTransportDto>(UnitOfWork, Mapper, Logger)
{
    protected override IGenericRepository<Transport> GetEntity() => UnitOfWork.Transports;
}
