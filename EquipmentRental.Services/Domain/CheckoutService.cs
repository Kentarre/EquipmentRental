using Domain.Models;
using EquipmentRental.Data.Repositories;
using EquipmentRental.Data.Repositories.Interfaces;
using EquipmentRental.Services.Domain.Interfaces;

namespace EquipmentRental.Services.Domain;

public class CheckoutService : ICheckoutService
{
    private readonly IPurchaseRepository _purchaseRepository;

    public CheckoutService(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    
    public async Task<Purchase> Checkout(Customer customer, Cart cart)
    {
        var purchase = Purchase.Create(cart);

        await _purchaseRepository.AddAsync(purchase);
        
        cart.Clear();

        return purchase;
    }
}