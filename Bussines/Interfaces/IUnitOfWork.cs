namespace Bussines.Interfaces;

public interface IUnitOfWork
{
    IFlightRepository Flights { get; }
    IJourneyRepository Journeys { get; }
    ITransportRepository Transports { get; }
    Task<int> SaveAsync();
}

