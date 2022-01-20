using EquipmentRental.Common.Enums;

namespace EquipmentRental.Common.Dtos;

public class ProductDto
{
    public string Name { get; }
    public int Days { get; }
    public EquipmentType Type { get; }
    public decimal Price { get; set; }
    public decimal Bonus { get; set; }

    public ProductDto(string name, int days, EquipmentType type, decimal price, decimal bonus)
    {
        Name = name;
        Days = days;
        Type = type;
        Price = price;
        Bonus = bonus;
    }
}