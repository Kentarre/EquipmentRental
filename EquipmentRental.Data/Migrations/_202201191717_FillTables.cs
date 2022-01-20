using System;
using System.Collections.Generic;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Common.Enums;
using EquipmentRental.Common.Models;
using FluentMigrator;

namespace EquipmentRental.Data.Migrations;

[Migration(202201191717)]
public class _202201191717_FillTables : Migration
{
    #region equipment

    private List<Equipment> _equipmentList = new()
    {
        new Equipment
        {
            Name = "Caterpillar",
            EquipmentType = EquipmentType.Heavy,
        },
        new Equipment
        {
            Name = "Kamaz",
            EquipmentType = EquipmentType.Regular,
        },
        new Equipment
        {
            Name = "Komatsu",
            EquipmentType = EquipmentType.Heavy,
        },
        new Equipment
        {
            Name = "Volvo",
            EquipmentType = EquipmentType.Regular,
        },
        new Equipment
        {
            Name = "Bosch",
            EquipmentType = EquipmentType.Specialized
        },
    };

    #endregion
    
    public override void Up()
    {
        Insert.IntoTable("Customer").Row(new { Id = Guid.NewGuid(), Name = "Alex" });

        foreach (var equipment in _equipmentList)
            Insert.IntoTable("Equipment").Row(new
                {Id = Guid.NewGuid(), EquipmentType = (int) equipment.EquipmentType, Name = equipment.Name});
    }

    public override void Down()
    {
    }
}