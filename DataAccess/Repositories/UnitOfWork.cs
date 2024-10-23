using Bussines.Interfaces;
using DataAccess.Data;

namespace DataAccess.Repositories;
public class UnitOfWork(ApiContext ctx) : IUnitOfWork, IDisposable
{
    private bool _disposed = false;
    private readonly ApiContext _context = ctx;
    private IFlightRepository? _flight;
    private IJourneyRepository? _journey;
    private ITransportRepository? _transport;

    public IFlightRepository Flights => _flight ??= new FlightRepository(_context);
    public IJourneyRepository Journeys => _journey ??= new JourneyRepository(_context);
    public ITransportRepository Transports => _transport ??= new TransportRepository(_context);


    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
