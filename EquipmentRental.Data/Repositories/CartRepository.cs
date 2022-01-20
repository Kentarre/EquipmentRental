using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Data.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    private readonly RentalDbContext _context;
    
    public CartRepository(RentalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Cart?> GetCartByCustomerIdAsync(Guid customerId)
    {
        return await DbSet.Include(x => x.Products).FirstOrDefaultAsync(x => x.CustomerId == customerId);
    }
}