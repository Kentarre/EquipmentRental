using Domain.Models;
using EquipmentRental.Common.Models;

namespace EquipmentRental.Services.Application.Interfaces;

public interface IProductService
{
    Task<Product> Create(Guid customerId, Equipment? equipment, int days = 0);
    Task<Product> Get(Guid productId);
}