using System.Collections.Generic;
using System.Linq;
using WMSDemo.Models;

namespace WMSDemo.Services
{
    public class InventoryService
    {
        private readonly List<InventoryItem> _inventoryItems;

        public InventoryService()
        {
            // Initialize with sample data
            _inventoryItems = new List<InventoryItem>
            {
                new InventoryItem { Id = 1, Name = "Widget A", Description = "High-quality widget", Quantity = 100, Price = 10.99m },
                new InventoryItem { Id = 2, Name = "Widget B", Description = "Economy widget", Quantity = 200, Price = 5.49m }
            };
        }

        public List<InventoryItem> GetInventoryItems() => _inventoryItems;

        public void AddInventoryItem(InventoryItem item)
        {
            item.Id = _inventoryItems.Max(i => i.Id) + 1; // Auto-generate ID
            _inventoryItems.Add(item);
        }

        public bool UpdateInventoryItem(int id, InventoryItem updatedItem)
        {
            var existingItem = _inventoryItems.FirstOrDefault(i => i.Id == id);
            if (existingItem == null) return false;

            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            existingItem.Quantity = updatedItem.Quantity;
            existingItem.Price = updatedItem.Price;

            return true;
        }

        public bool DeleteInventoryItem(int id)
        {
            var item = _inventoryItems.FirstOrDefault(i => i.Id == id);
            if (item == null) return false;

            _inventoryItems.Remove(item);
            return true;
        }
    }
}
