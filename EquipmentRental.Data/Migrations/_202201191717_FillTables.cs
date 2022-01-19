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
            Type = EquipmentType.Heavy,
        },
        new Equipment
        {
            Name = "Kamaz",
            Type = EquipmentType.Regular,
        },
        new Equipment
        {
            Name = "Komatsu",
            Type = EquipmentType.Heavy,
        },
        new Equipment
        {
            Name = "Volvo",
            Type = EquipmentType.Regular,
        },
        new Equipment
        {
            Name = "Bosch",
            Type = EquipmentType.Specialized
        },
    };

    #endregion
    
    public override void Up()
    {
        Insert.IntoTable("Customer").Row(new { Id = Guid.NewGuid(), Name = "Alex" });

        foreach (var equipment in _equipmentList)
            Insert.IntoTable("Equipment").Row(new
                {Id = Guid.NewGuid(), Type = (int) equipment.Type, Name = equipment.Name});
    }

    public override void Down()
    {
    }
}