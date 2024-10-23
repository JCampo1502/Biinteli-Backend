using Bussines.Entities;

namespace Bussines.Interfaces;

public interface IJourneyRepository:IGenericRepository<Journey>
{
    Task<List<Journey>> FilterByOriginAndDestination(string origin, string destination);
}
