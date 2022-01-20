using Domain.Models;
using EquipmentRental.Common.Dtos;
using EquipmentRental.Common.Models;
using EquipmentRental.Data.Repositories.Interfaces;
using EquipmentRental.Services.Application.Interfaces;
using EquipmentRental.Services.Domain.Interfaces;

namespace EquipmentRental.Services.Application;

public class CartService : ICartService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICheckoutService _checkoutService;

    public CartService(ICustomerRepository customerRepository, ICartRepository cartRepository,
        IEquipmentRepository equipmentRepository, IProductRepository productRepository,
        ICheckoutService checkoutService)
    {
        _customerRepository = customerRepository;
        _cartRepository = cartRepository;
        _equipmentRepository = equipmentRepository;
        _productRepository = productRepository;
        _checkoutService = checkoutService;
    }

    public async Task<CartDto> Add(Guid customerId, Guid equipmentId, int days)
    {
        var customer = await _customerRepository.GetAsync(customerId);

        if (customer == null)
            throw new Exception($"No customer with id: {customerId}");
        
        var equipment = await _equipmentRepository.GetAsync(equipmentId);
        var cart =  await _cartRepository.GetCartByCustomerIdAsync(customerId);

        if (cart == null)
        {
            cart = Cart.Create(customer);
            await _cartRepository.AddAsync(cart);
        }       

        var product = Product.Create(cart, equipment, days);
        
        cart.Add(product);
        
        await _productRepository.AddAsync(product);
        await _cartRepository.UpdateAsync(cart);

        return new CartDto
        {
            Products = cart.Products.Select(x => new ProductDto(x.Name, x.Days, x.EquipmentType, x.Price, x.Bonus)).ToList(),
            CustomerId = customerId
        };
    }

    public async Task<CartDto> Remove(Guid customerId, Guid productId)
    {
        var cart =  await _cartRepository.GetCartByCustomerIdAsync(customerId);

        if (cart == null)
            throw new Exception();
        
        var product = await _productRepository.GetAsync(productId);
        
        cart.Remove(product);

        await _productRepository.RemoveAsync(product);
        await _cartRepository.UpdateAsync(cart);

        return new CartDto
        {
            Products = cart.Products.Select(x => new ProductDto(x.Name, x.Days, x.EquipmentType, x.Price, x.Bonus)).ToList(),
            CustomerId = customerId
        };
    }

    public async Task<CartDto?> Get(Guid customerId)
    {
        var cart = await _cartRepository.GetCartByCustomerIdAsync(customerId);

        return cart != null
            ? new CartDto
            {
                Products = cart.Products.Select(x => new ProductDto(x.Name, x.Days, x.EquipmentType, x.Price, x.Bonus)).ToList(),
                CustomerId = customerId
            }
            : null;
    }

    public async Task<CheckoutResultDto> Checkout(Guid customerId)
    {
        var customer = await _customerRepository.GetAsync(customerId);
        var cart =  await _cartRepository.GetCartByCustomerIdAsync(customerId);
        
        if (cart == null)
            throw new Exception();
        
        var purchase = Purchase.Create(cart);

        await _checkoutService.Checkout(customer, cart);

        return new CheckoutResultDto
        {
            PurchaseId = purchase.Id,
            TotalPrice = cart.TotalPrice,
            TotalBonuses = cart.TotalBonuses
        };
    }
}