using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Onion.Domain.Model.Entities.Base;
using Onion.Domain.Services.Persistance.Interfaces;
using System.Linq.Expressions;

namespace Onion.Infrastructure.Persistence.EF;

public class EFRepository<T> : IRepository<T> where T : EntityBase<Guid>
{
    protected readonly DbContext _context;
    internal DbSet<T> _dbSet;
    public readonly ILogger<EFRepository<T>> _logger;

    //Injecting the context object and logger instance to constructor
    public EFRepository(DbContext context, ILogger<EFRepository<T>> logger = null)
    {
        _context = context;
        _dbSet = context.Set<T>();
        _logger = logger;
    }


    //This method retrieves a single object with given id
    public virtual async Task<T> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    //This method adds an entity to the database
    public virtual async Task<bool> Add(T entity)
    {
        //Adding entity to DbSet and returning true if successful
        await _dbSet.AddAsync(entity);
        return true;
    }

    //This method deletes an entity with given id from the database
    public virtual async Task<bool> Delete(Guid id)
    {
        try
        {
            //Fetching the entity with given id
            var exist = await _dbSet.FindAsync(id);

            //Returning false if entity with given id doesn't exist
            if (exist == null) return false;

            //Removing the entity from DbSet
            _dbSet.Remove(exist);

            //Returning true if successful
            return true;
        }
        catch (Exception ex)
        {
            //Logging the error message if any exception occurs
            _logger.LogError(ex, "{Repo} Delete function error", typeof(IRepository<T>));
            return false;
        }
    }

    //This method retrieves all the entities of a given type from the database
    public async Task<IEnumerable<T>> All()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            //Logging the error message if any exception occurs
            _logger.LogError(ex, "{Repo} All function error", typeof(IRepository<T>));
            return new List<T>();
        }
    }

    //This method retrieves all the entities of a given type from the database that match the given predicate
    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    //This method updates an entity in the database or inserts it if it doesn't exist
    public virtual async Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }
}

