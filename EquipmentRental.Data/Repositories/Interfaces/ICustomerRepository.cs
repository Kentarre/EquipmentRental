using System;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Common.Dtos;

namespace EquipmentRental.Data.Repositories.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer> FindById(Guid customerId);
}