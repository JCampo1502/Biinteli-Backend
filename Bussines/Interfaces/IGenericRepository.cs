using System.Linq.Expressions;

namespace Bussines.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> FindFirstAsync();
    Task<T?> FindFirstAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);

    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    void Remove(T entity);
    void RemoveRange(List<T> entities);
    void Update(T entity);
}
