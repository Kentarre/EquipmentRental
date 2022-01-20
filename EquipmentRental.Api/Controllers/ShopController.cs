using System;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Data.Repositories.Interfaces;
using EquipmentRental.Services.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ICartService _cartService;

        public ShopController(IEquipmentRepository equipmentRepository, ICartService cartService)
        {
            _equipmentRepository = equipmentRepository;
            _cartService = cartService;
        }
        
        [HttpGet]
        [Route("equipment")]
        public async Task<JsonResult> GetAvailableEquipment()
        {
            var equipment = await _equipmentRepository.GetAllAsync();
            
            return Json(equipment);
        }
        
        [HttpGet]
        [Route("checkout")]
        public async Task<JsonResult> CheckOut(Guid customerId)
        {
            var purchase = await _cartService.Checkout(customerId);
            
            return Json(new {purchase.TotalPrice, purchase.TotalBonuses});
        }

        [HttpGet]
        [Route("add")]
        public async Task<JsonResult> AddItem(Guid customerId, Guid equipmentId, int days)
        {
            var cart = _cartService.Add(customerId, equipmentId, days);

            return Json(cart);
        }
        
        [HttpGet]
        [Route("remove")]
        public async Task<JsonResult> RemoveItem(Guid customerId, Guid productId)
        {
            var cart = _cartService.Remove(customerId, productId);

            return Json(cart);
        }

        
        [HttpGet]
        [Route("state")]
        public async Task<JsonResult> GetState(Guid customerId)
        {
            var cart = await _cartService.Get(customerId);
            return Json(cart);
        }
    }
}