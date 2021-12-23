using System;
using Domain.Models;

namespace Domain
{
    public static class CustomerRepoMock
    {
        private static Customer _customer = new("Alex");

        public static Customer GetCustomer()
        {
            return _customer;
        }

        public static void UpdateCustomer(Customer customer)
        {
            _customer = customer;
        }
    }
}