using EquipmentRental.Common.Enums;

namespace EquipmentRental.Common.Dtos;

public class ProductDto
{
    public string Name { get; }
    public int Days { get; }
    public EquipmentType Type { get; }

    public ProductDto(string name, int days, EquipmentType type)
    {
        Name = name;
        Days = days;
        Type = type;
    }
}