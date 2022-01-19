using System;
using System.Collections.Generic;

namespace Domain.Models;

public class Purchase : IDomainModel
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid CustomerId { get; set; }
    public List<Product> PurchasedProducts { get; set; }

    public static Purchase Create(Cart cart)
    {
        return new Purchase
        {
            Id = Guid.NewGuid(),
            CreatedOn = DateTime.Now,
            CustomerId = cart.CustomerId,
            PurchasedProducts = cart.Products
        };
    }
}