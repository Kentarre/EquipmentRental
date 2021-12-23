using System;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        public Guid Create(Customer customer)
        {
            return CustomerRepoMock.GetCustomer().Id;
        }

        public Customer GetCustomerById(Guid id)
        {
            return CustomerRepoMock.GetCustomer();
        }

        public void Update(Customer customer)
        {
            CustomerRepoMock.UpdateCustomer(customer);
        }
    }
}