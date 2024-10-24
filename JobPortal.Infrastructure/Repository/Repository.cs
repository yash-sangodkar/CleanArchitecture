using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeknorixJobs.Application.Abstraction.Repository;

namespace TeknorixJobs.Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity>  where TEntity : class
{
    private readonly JobDbContext _dbContext;
    public Repository(JobDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null) 
        {
            throw new ArgumentNullException(nameof(entity));
        }
        try
        {
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }

    public async Task DeleteAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        try
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        try
        {
            return await _dbContext.Set<TEntity>().AnyAsync(predicate);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        try
        {
            return  await _dbContext.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IQueryable<TEntity> GetAll()
    {
        try
        {
            return _dbContext.Set<TEntity>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        try
        {
           return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        try
        {
             _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
