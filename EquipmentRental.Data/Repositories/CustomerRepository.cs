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
}