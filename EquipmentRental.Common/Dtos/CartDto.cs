using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentRental.Common.Dtos;

public class CartDto
{
    public Guid CustomerId { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<ProductDto> Products { get; set; }
    public decimal TotalPrice => Products.Sum(x => x.Price);
    public decimal TotalBonus => Products.Sum(x => x.Bonus);
}