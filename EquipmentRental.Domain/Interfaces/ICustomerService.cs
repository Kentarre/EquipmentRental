using System;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICustomerService
    {
        Guid Create(Customer customer);
        void Update(Customer customer);
        Customer GetCustomerById(Guid id);
    }
}