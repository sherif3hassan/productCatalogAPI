using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Domain.Entities;
using ProductCatalogAPI.Infrastructure.DatabaseContext;

namespace ProductCatalogAPI.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ProductCatalogContext _dbContext;

    public BaseRepository(ProductCatalogContext productCatalogContext)
    {
        _dbContext = productCatalogContext;
    }

    public async Task CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);


        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
