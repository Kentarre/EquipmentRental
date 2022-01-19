using System;
using EquipmentRental.Common.Enums;

namespace EquipmentRental.Common.Models;

public class Equipment
{
    public Guid Id { get; set; }
    public EquipmentType Type { get; set; }
    public string Name { get; set; }
}