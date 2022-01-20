using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class, IDomainModel
{
    private readonly RentalDbContext _context;
    protected readonly DbSet<T> DbSet;

    public Repository(RentalDbContext context)
    {
        _context = context;
        DbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return (await DbSet.ToListAsync()).FirstOrDefault(x => x.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task RemoveAsync(T entity)
    {
        DbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}