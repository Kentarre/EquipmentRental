using System;

namespace EquipmentRental.Common.Dtos;

public class PurchaseDto
{
    public Guid Id { get; set; }
    public CartDto CartDto { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal BonusesTotal { get; set; }
}