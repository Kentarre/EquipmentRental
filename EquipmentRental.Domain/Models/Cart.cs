using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Helpers;

namespace Domain.Models;

public class Cart : IDomainModel
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public readonly List<Product> Products = new();
    public decimal TotalPrice => Products.Sum(x => x.Price);
    public decimal TotalBonuses => Products.Sum(x => x.Bonus);

    public static Cart Create(Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        return new Cart
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
        };
    }

    public void Add(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        Products.Add(product);
    }

    public void Remove(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        Products.Remove(product);
    }

    public void Clear()
    {
        Products.Clear();
    }
}