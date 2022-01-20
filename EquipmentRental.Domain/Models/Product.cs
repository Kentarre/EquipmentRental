using System;
using Domain.Helpers;
using EquipmentRental.Common.Enums;
using EquipmentRental.Common.Models;

namespace Domain.Models;

public class Product : IDomainModel
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public string Name { get; set; }
    public EquipmentType EquipmentType { get; set; }
    public int Days { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal Price { get; set; }
    public decimal Bonus { get; set; }
    public Guid? PurchaseId { get; set; }

    public static Product Create(Cart cart, Equipment equipment, int days = 0)
    {
        if (equipment == null)
            throw new ArgumentNullException(nameof(equipment));
        
        if (days == 0)
            throw new ArgumentException(nameof(days));

        return new Product
        {
            Id = Guid.NewGuid(),
            Name = equipment.Name,
            EquipmentType = equipment.EquipmentType,
            Days = days,
            CreatedOn = DateTime.Now,
            Price = Calculator.GetPrice(equipment.EquipmentType, days),
            Bonus = Calculator.GetBonus(equipment.EquipmentType),
            CartId = cart.Id
        };
    }
}