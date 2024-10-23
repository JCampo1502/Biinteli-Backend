using Bussines.Entities;
using Bussines.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class TransportRepository(ApiContext context) : GenericRepository<Transport>, ITransportRepository
{
    protected override DbSet<Transport> Entity { get; } = context.Set<Transport>();

    protected override async Task<List<Transport>> RequestAsync() => await Entity.ToListAsync();
   
}
