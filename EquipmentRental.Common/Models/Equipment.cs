using System;
using EquipmentRental.Common.Enums;

namespace EquipmentRental.Common.Models;

public class Equipment
{
    public Guid Id { get; set; }
    public EquipmentType EquipmentType { get; set; }
    public string Name { get; set; }
}