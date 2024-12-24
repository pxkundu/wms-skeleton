using Microsoft.AspNetCore.Mvc;
using WMSDemo.Models;
using WMSDemo.Services;

namespace WMSDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController()
        {
            _inventoryService = new InventoryService();
        }

        [HttpGet]
        public IActionResult GetAllInventoryItems()
        {
            var items = _inventoryService.GetInventoryItems();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult AddInventoryItem([FromBody] InventoryItem item)
        {
            _inventoryService.AddInventoryItem(item);
            return CreatedAtAction(nameof(GetAllInventoryItems), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInventoryItem(int id, [FromBody] InventoryItem updatedItem)
        {
            var success = _inventoryService.UpdateInventoryItem(id, updatedItem);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInventoryItem(int id)
        {
            var success = _inventoryService.DeleteInventoryItem(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
