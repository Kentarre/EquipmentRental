using Domain.Models;
using EquipmentRental.Common.Models;
using EquipmentRental.Data.Repositories.Interfaces;
using EquipmentRental.Services.Application.Interfaces;

namespace EquipmentRental.Services.Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Create(Cart cart, Equipment? equipment, int days = 0)
    {
        var product = Product.Create(cart, equipment, days);

        await _productRepository.AddAsync(product);

        return product;
    }

    public async Task<Product> Get(Guid productId)
    {
        return await _productRepository.GetAsync(productId);
    }

    public async Task Add(Product product)
    {
        await _productRepository.AddAsync(product);
    }
}