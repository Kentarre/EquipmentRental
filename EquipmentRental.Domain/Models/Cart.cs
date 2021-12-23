using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Cart
    {
        public List<Item> Items { get; }

        public Cart()
        {
            Items = new List<Item>();
        }
        
        public void Add(Item item)
        {
            if (item.Days <= 0)
                throw new Exception("Days input invalid");
            
            if (item.Equipment == null)
                throw new Exception("Equipment cant be null");

            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.RemoveAll(x => x == item);
        }
    }
}