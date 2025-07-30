using System.Linq.Expressions;
using Ai_ChatApp.Domain.Commons;

namespace Ai_ChatApp.Data.Repositories;

public interface IRepository<T> where T : Auditable
{
    Task<T> InsertAsync(T entity);
    Task<T> DropAsync(T entity);
    Task<T> SelectAsync(Expression<Func<T, bool>> expression,
        string[] includes = null,
        bool isTracked = true);
    Task<IEnumerable<T>> SelectAsEnumerableAsync(
        Expression<Func<T, bool>> expression = null,
        string[] includes = null,
        bool isTracked = true);
    IQueryable<T> SelectAsQueryable(
        Expression<Func<T, bool>> expression = null,
        string[] includes = null,
        bool isTracked = true);
}