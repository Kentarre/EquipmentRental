using System;
using Domain.Helpers;
using EquipmentRental.Common.Enums;
using EquipmentRental.Common.Models;

namespace Domain.Models;

public class Product : IDomainModel
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public EquipmentType Type { get; set; }
    public int Days { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal Price { get; set; }
    public decimal Bonus { get; set; }

    public static Product Create(Guid customerId, Equipment equipment, int days = 0)
    {
        if (equipment == null)
            throw new ArgumentNullException(nameof(equipment));
        
        if (days == 0)
            throw new ArgumentException(nameof(days));

        return new Product
        {
            Id = Guid.NewGuid(),
            Name = equipment.Name,
            Type = equipment.Type,
            Days = days,
            CreatedOn = DateTime.Now,
            Price = Calculator.GetPrice(equipment.Type, days),
            Bonus = Calculator.GetBonus(equipment.Type),
            CustomerId = customerId
        };
    }
}