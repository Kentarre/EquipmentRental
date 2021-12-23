using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEquipmentService
    {
        List<Equipment> GetAvailableEquipment();
        Equipment GetItem(Guid itemId);
    }
}