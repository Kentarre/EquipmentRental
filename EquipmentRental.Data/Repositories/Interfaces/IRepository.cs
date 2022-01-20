using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace EquipmentRental.Data.Repositories.Interfaces;

public interface IRepository<T> where T : class, IDomainModel
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task RemoveAsync(T entity);
}