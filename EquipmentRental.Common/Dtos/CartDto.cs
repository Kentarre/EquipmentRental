using System;
using System.Collections.Generic;

namespace EquipmentRental.Common.Dtos;

public class CartDto
{
    public Guid CustomerId { get; set; }
    public List<ProductDto> Products { get; set; }
}