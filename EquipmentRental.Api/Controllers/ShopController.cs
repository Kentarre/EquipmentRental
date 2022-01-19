using System;
using System.Threading.Tasks;
using Domain.Models;
using EquipmentRental.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public ShopController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        [HttpGet]
        [Route("equipment")]
        public async Task<JsonResult> GetAvailableEquipment()
        {
            var equipment = await _equipmentRepository.GetAllAsync();
            
            return Json(equipment);
        }
        
        // [HttpGet]
        // [Route("checkout")]
        // public async Task<JsonResult> CheckOut(Guid customerId)
        // {
        //     var customer = await _customerService.GetCustomerByIdAsync(customerId);
        //     var purchase = customer.Checkout();
        //
        //     return Json(new {purchase.Total, purchase.Bonuses});
        // }

        // [HttpGet]
        // [Route("add")]
        // public async Task<JsonResult> AddItem(Guid customerId, Guid id, int days)
        // {
        //     var customer = await _customerService.GetCustomerByIdAsync(customerId);
        //     var equipment = _equipmentService.GetItem(id);
        //
        //     var item = new Item(equipment, days);
        //     
        //     customer.Cart.Add(item);
        //
        //     return Json(new {Result = "Ok"});
        // }
        //
        // [HttpGet]
        // [Route("state")]
        // public JsonResult GetState(Guid customerId)
        // {
        //     return Json(_customerService.GetCustomerByIdAsync(customerId));
        // }
    }
}