using Domain.Models;
using EquipmentRental.Data.Repositories.Interfaces;

namespace EquipmentRental.Data.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(RentalDbContext context) : base(context)
    {
    }
}