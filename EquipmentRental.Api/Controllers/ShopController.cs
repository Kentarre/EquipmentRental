using System;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ICustomerService _customerService;

        public ShopController(IEquipmentService equipmentService, ICustomerService customerService)
        {
            _equipmentService = equipmentService;
            _customerService = customerService;
        }
        
        [HttpGet]
        [Route("equipment")]
        public JsonResult GetAvailableEquipment()
        {
            var equipment = _equipmentService.GetAvailableEquipment();
            
            return Json(equipment);
        }
        
        [HttpGet]
        [Route("checkout")]
        public JsonResult CheckOut(Guid customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);
            var purchase = customer.Checkout();

            return Json(new {purchase.Total, purchase.Bonuses});
        }

        [HttpGet]
        [Route("add")]
        public JsonResult AddItem(Guid customerId, Guid id, int days)
        {
            var customer = _customerService.GetCustomerById(customerId);
            var equipment = _equipmentService.GetItem(id);

            var item = new Item(equipment, days);
            
            customer.Cart.Add(item);

            return Json(new {Result = "Ok"});
        }

        [HttpGet]
        [Route("state")]
        public JsonResult GetState(Guid customerId)
        {
            return Json(_customerService.GetCustomerById(customerId));
        }
    }
}