using System;

namespace EquipmentRental.Common.Dtos;

public class CheckoutResultDto
{
    public Guid PurchaseId { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalBonuses { get; set; }
}