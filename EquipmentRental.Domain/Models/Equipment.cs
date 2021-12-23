using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public EquipmentType Type { get; set; }
        public string Name { get; set; }
    }
}