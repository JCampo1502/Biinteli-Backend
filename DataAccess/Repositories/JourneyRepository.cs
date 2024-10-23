using Bussines.Entities;
using Bussines.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;
public class JourneyRepository(ApiContext context) : GenericRepository<Journey>, IJourneyRepository
{
    protected override DbSet<Journey> Entity { get; }= context.Set<Journey>();

    protected override async Task<List<Journey>> RequestAsync()
    {
        var journeys = await (
         from journey in context.Journeys
         join flight in context.Flights on journey.Id equals flight.JourneyId into flightGroup
         select new Journey
         {
             Id = journey.Id,
             Origin = journey.Origin,
             Destination = journey.Destination,
             Price = journey.Price,
             Flights = flightGroup.Select(f => new Flight
             {
                 Id = f.Id,
                 Origin = f.Origin,
                 Destination = f.Destination,
                 Price = f.Price,
                 JourneyId = f.JourneyId,
                 Transports = context.Transports
                     .Where(t => t.FlightId == f.Id)
                     .Select(t => new Transport
                     {
                         Id = t.Id,
                         FlightCarrier = t.FlightCarrier,
                         FlightNumber = t.FlightNumber,
                         FlightId = t.FlightId
                     }).ToList()
             }).ToList()
         }).ToListAsync();

        return journeys;
    }

    public async Task<List<Journey>> FilterByOriginAndDestination(string origin, string destination) => await GetAllAsync(j => 
        j.Origin.Trim().Equals(origin.Trim(), StringComparison.CurrentCultureIgnoreCase) 
    && j.Destination.Trim().Equals(destination.Trim(), StringComparison.CurrentCultureIgnoreCase));
}
