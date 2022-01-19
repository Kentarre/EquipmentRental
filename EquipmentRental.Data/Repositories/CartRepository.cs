using System;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Data.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(RentalDbContext context) : base(context)
    {   
    }

    public async Task<Cart?> GetCartByCustomerIdAsync(Guid customerId)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.CustomerId == customerId);;
    }
}