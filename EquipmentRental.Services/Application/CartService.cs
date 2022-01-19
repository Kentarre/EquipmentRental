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
    private readonly IProductService _productService;
    private readonly ICheckoutService _checkoutService;

    public CartService(ICustomerRepository customerRepository, ICartRepository cartRepository,
        IEquipmentRepository equipmentRepository, IProductService productService,
        ICheckoutService checkoutService)
    {
        _customerRepository = customerRepository;
        _cartRepository = cartRepository;
        _equipmentRepository = equipmentRepository;
        _productService = productService;
        _checkoutService = checkoutService;
    }

    public async Task<CartDto> Add(Guid customerId, Equipment equipmentDto, int days)
    {
        var customer = await _customerRepository.FindById(customerId);
        var cart =  await _cartRepository.GetCartByCustomerIdAsync(customerId);

        if (cart == null)
        {
            cart = Cart.Create(customer);
            await _cartRepository.AddAsync(cart);
        }

        var equipment = await _equipmentRepository.GetAsync(equipmentDto.Id);
        var product = await _productService.Create(customer.Id, equipment, days);
        
        cart.Add(product);

        await _cartRepository.UpdateAsync(cart);

        return new CartDto
        {
            Products = cart.Products.Select(x => new ProductDto(x.Name, x.Days, x.Type)).ToList(),
            CustomerId = customerId
        };
    }

    public async Task<CartDto> Remove(Guid customerId, Guid productId)
    {
        var cart =  await _cartRepository.GetCartByCustomerIdAsync(customerId);

        if (cart == null)
            throw new Exception();
        
        var product = await _productService.Get(productId);
        
        cart.Remove(product);

        await _cartRepository.UpdateAsync(cart);
        
        return new CartDto
        {
            Products = cart.Products.Select(x => new ProductDto(x.Name, x.Days, x.Type)).ToList(),
            CustomerId = customerId
        };
    }

    public async Task<CartDto?> Get(Guid customerId)
    {
        var cart = await _cartRepository.GetAsync(customerId);

        return cart != null
            ? new CartDto
            {
                Products = cart.Products.Select(x => new ProductDto(x.Name, x.Days, x.Type)).ToList(),
                CustomerId = customerId
            }
            : null;
    }

    public async Task<CheckoutResultDto> Checkout(Guid customerId)
    {
        var customer = await _customerRepository.FindById(customerId);
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