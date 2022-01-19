using System;

namespace Domain.Models;

public class Customer : IDomainModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public static Customer Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));
        
        return new Customer
        {
            Id = Guid.NewGuid(),
            Name = name
        };
    }
}