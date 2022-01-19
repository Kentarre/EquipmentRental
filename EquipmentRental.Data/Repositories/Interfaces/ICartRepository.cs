using System;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Common.Dtos;

namespace EquipmentRental.Data.Repositories.Interfaces;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetCartByCustomerIdAsync(Guid customerId);
}