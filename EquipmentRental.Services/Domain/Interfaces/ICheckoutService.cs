using Domain.Models;

namespace EquipmentRental.Services.Domain.Interfaces;

public interface ICheckoutService
{
    Task<Purchase> Checkout(Customer customer, Cart cart);
}