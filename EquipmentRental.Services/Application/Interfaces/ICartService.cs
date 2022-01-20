using Domain.Models;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Common.Models;

namespace EquipmentRental.Services.Application.Interfaces;

public interface ICartService
{
    Task<CartDto> Add(Guid customerId, Guid equipmentId, int days);
    Task<CartDto> Remove(Guid customerId, Guid productId);
    Task<CartDto?> Get(Guid customerId);
    Task<CheckoutResultDto> Checkout(Guid customerId);
}