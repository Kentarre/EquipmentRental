using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Common.Models;
using EquipmentRental.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Data.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly RentalDbContext _context;
    protected readonly DbSet<Equipment> DbSet;
    
    public EquipmentRepository(RentalDbContext context)
    {
        _context = context;
        DbSet =  context.Set<Equipment>();
    }
    
    public async Task<List<Equipment>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<Equipment?> GetAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Equipment> AddAsync(Equipment entity)
    {
        await DbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<Equipment> entities)
    {
        await DbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<Equipment> UpdateAsync(Equipment entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}