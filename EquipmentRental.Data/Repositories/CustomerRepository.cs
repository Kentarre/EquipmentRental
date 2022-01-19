using System;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Data.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(RentalDbContext context) : base(context)
    {
    }

    public async Task<Customer> FindById(Guid customerId)
    {
        var customer = await DbSet.FirstOrDefaultAsync(x => x.Id == customerId);

        if (customer == null)
            throw new Exception($"No customer with id: {customer}");
        
        return customer;
    }
}