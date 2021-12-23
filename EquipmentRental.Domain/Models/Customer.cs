using System;
using System.Collections.Generic;
using System.Text.Json;
using Domain.Interfaces;

namespace Domain.Models
{
    public class Customer
    {
        public Guid Id { get; }
        public Cart Cart { get; }
        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
            Id = new Guid("F1DE8A65-875A-4A4F-8F49-2F4BEDE048EA");
            Cart = new Cart();
        }
        
        public Purchase Checkout()
        {
            return new(Cart.Items);
        }
    }
}