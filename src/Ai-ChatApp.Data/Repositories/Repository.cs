using System.Linq.Expressions;
using Ai_ChatApp.Data.Contexts;
using Ai_ChatApp.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Ai_ChatApp.Data.Repositories;

public sealed class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext context;
    private readonly DbSet<T> set;
    public Repository(AppDbContext context)
    {
        this.context = context;
        set = context.Set<T>();
    }
    public async Task<T> InsertAsync(T entity)
    {
        return (await context.AddAsync(entity)).Entity;
    }

    public async Task<T> DropAsync(T entity)
    {
        return await Task.FromResult(set.Remove(entity).Entity);
    }

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracked = true)
    {
        var query = set.Where(expression);
        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        if (!isTracked)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<T>> SelectAsEnumerableAsync(Expression<Func<T,
        bool>> expression = null,
        string[] includes = null,
        bool isTracked = true)
    {
        var query = expression is null ? set : set.Where(expression);
        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        if (!isTracked)
            query = query.AsNoTracking();

        return await query.ToListAsync();

    }

    public IQueryable<T> SelectAsQueryable(Expression<Func<T,
        bool>> expression = null,
        string[] includes = null,
        bool isTracked = true)
    {
        var query = expression is null ? set : set.Where(expression);
        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        if (!isTracked)
            query = query.AsNoTracking();

        return query;
    }

}