using Bussines.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories;

public abstract class GenericRepository<T> where T : class
{
    protected abstract DbSet<T> Entity { get; }
    protected abstract Task<List<T>> RequestAsync();

    public  async virtual Task<T?> FindFirstAsync() => (await RequestAsync()).FirstOrDefault();

    public async virtual Task<T?> FindFirstAsync(Expression<Func<T, bool>> expression) =>
        (await RequestAsync()).AsQueryable().FirstOrDefault(expression);

    public async virtual Task AddAsync(T entity) => await Entity.AddAsync(entity);

    public async virtual Task AddRangeAsync(List<T> entities) => await Entity.AddRangeAsync(entities);

    public virtual void Remove(T entity) => Entity.Remove(entity);

    public virtual void RemoveRange(List<T> entities) => Entity.RemoveRange(entities);

    public virtual void Update(T entity) => Entity.Update(entity);
    
    public virtual async Task<List<T>> GetAllAsync() => await RequestAsync();

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression) =>
        (await RequestAsync()).AsQueryable().Where(expression).ToList();
}
