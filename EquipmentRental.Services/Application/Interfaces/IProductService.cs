using Domain.Models;
using EquipmentRental.Common.Models;

namespace EquipmentRental.Services.Application.Interfaces;

public interface IProductService
{
    Task<Product> Create(Cart cart, Equipment? equipment, int days = 0);
    Task<Product> Get(Guid productId);
    Task Add(Product product);
}