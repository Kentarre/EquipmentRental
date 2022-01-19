
using Domain.Models;
using EquipmentRental.Data.Repositories.Interfaces;

namespace EquipmentRental.Data.Repositories;

public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(RentalDbContext context) : base(context)
    {
    }
}