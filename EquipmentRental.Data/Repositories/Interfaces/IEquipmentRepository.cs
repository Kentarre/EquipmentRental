using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentRental.Common.Models;

namespace EquipmentRental.Data.Repositories.Interfaces;

public interface IEquipmentRepository
{
    Task<List<Equipment>> GetAllAsync();
    Task<Equipment?> GetAsync(Guid id);
    Task<Equipment> AddAsync(Equipment entity);
    Task AddRangeAsync(IEnumerable<Equipment> entities);
    Task<Equipment> UpdateAsync(Equipment entity);
}