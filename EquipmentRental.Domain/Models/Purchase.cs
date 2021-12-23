using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Models
{
    public class Purchase
    {
        public double Total { get; }
        public int Bonuses { get; }
        private List<Item> Items { get; }

        public Purchase(List<Item> items)
        {
            Items = items;
            
            foreach (var item in items)
            {
                Total += CalculatePrice(item);
                Bonuses += CalculateBonuses(item);
            }
        }

        public string GenerateInvoice()
        {
            var items = Items.Aggregate(string.Empty,
                (current, item) => current + $"{item.Equipment.Name} - {item.Days} - {CalculatePrice(item)}");

            return JsonSerializer.Serialize(new
            {
                Items = items,
                Total,
                Bonuses
            });
        }

        private double CalculatePrice(Item item)
        {
            if (item.Days <= 0)
                throw new Exception("Days count not valid");

            return item.Equipment.Type switch
            {
                EquipmentType.Heavy => (int) FeeType.OneTime + (int) FeeType.Premium * item.Days,
                EquipmentType.Regular => (int) FeeType.OneTime + (int) FeeType.Premium * 2 +
                                         (int) FeeType.Regular * (item.Days - 2),
                EquipmentType.Specialized => (int) FeeType.Premium * 3 + (int) FeeType.Regular * (item.Days - 3),
                _ => throw new Exception("Unknown equipment type")
            };
        }

        private int CalculateBonuses(Item item)
        {
            return item.Equipment.Type switch
            {
                EquipmentType.Heavy => 2,
                EquipmentType.Regular => 1,
                EquipmentType.Specialized => 1,
                _ => throw new Exception("Unknown equipment type")
            };
        }
    }
}