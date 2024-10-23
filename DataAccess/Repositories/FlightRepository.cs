using Bussines.Entities;
using Bussines.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories;

public class FlightRepository(ApiContext context) : GenericRepository<Flight>, IFlightRepository
{
    protected override async Task<List<Flight>> RequestAsync()
    {
        var flights = await (
            from flight in context.Flights
            join transport in context.Transports
            on flight.Id equals transport.FlightId into transportGroup
            select new Flight
            {
                Id = flight.Id,
                Origin = flight.Origin,
                Destination = flight.Destination,
                Price = flight.Price,
                JourneyId = flight.JourneyId,
                Journey = flight.Journey,
                Transports = transportGroup.Select(t => new Transport
                {
                    Id = t.Id,
                    FlightCarrier = t.FlightCarrier,
                    FlightNumber = t.FlightNumber,
                    FlightId = t.FlightId
                }).ToList()
            }).ToListAsync();

        return flights;
    }

    protected override DbSet<Flight> Entity { get; } = context.Set<Flight>();
   
}