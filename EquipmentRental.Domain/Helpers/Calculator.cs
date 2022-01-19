using System;
using EquipmentRental.Common.Enums;

namespace Domain.Helpers;

public static class Calculator
{
    public static decimal GetPrice(EquipmentType type, int days)
    {
        if (days <= 0)
            throw new Exception("Days count not valid");

        return type switch
        {
            EquipmentType.Heavy => (decimal) FeeType.OneTime + (decimal) FeeType.Premium * days,
            EquipmentType.Regular => (decimal) FeeType.OneTime + (decimal) FeeType.Premium * 2 +
                                     (decimal) FeeType.Regular * (days - 2),
            EquipmentType.Specialized => (decimal) FeeType.Premium * 3 + (decimal) FeeType.Regular * (days - 3),
            _ => throw new Exception("Unknown equipment type")
        };
    }

    public static decimal GetBonus(EquipmentType type)
    {
        return type switch
        {
            EquipmentType.Heavy => 2,
            EquipmentType.Regular => 1,
            EquipmentType.Specialized => 1,
            _ => throw new Exception("Unknown equipment type")
        };
    }
}