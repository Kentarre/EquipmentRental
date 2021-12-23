using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly List<Equipment> _equipments = new()
        {
            new Equipment
            {
                Id = new Guid("20016FC9-79E1-4BBE-8F70-ED5DB66517A3"),
                Name = "Caterpillar",
                Type = EquipmentType.Heavy,
            },
            new Equipment
            {
                Id = new Guid("A663F8E2-AEF4-47F8-B03B-CC46D9C25437"),
                Name = "Kamaz",
                Type = EquipmentType.Regular,
            },
            new Equipment
            {
                Id = new Guid("27A49541-3885-4311-BEE0-E6024F7F3277"),
                Name = "Komatsu",
                Type = EquipmentType.Heavy,
            },
            new Equipment
            {
                Id = new Guid("9C08318D-6B41-4247-B68A-C5F7BEC7BCF4"),
                Name = "Volvo",
                Type = EquipmentType.Regular,
            },
            new Equipment
            {
                Id = new Guid("44A17BCE-E4A6-429D-A694-846FB0763C63"),
                Name = "Bosch",
                Type = EquipmentType.Specialized
            },
        };

        public Equipment GetItem(Guid itemId)
        {
            return _equipments.First(x => x.Id == itemId);
        } 
        
        public List<Equipment> GetAvailableEquipment()
        {
            return _equipments;
        }
    }
}