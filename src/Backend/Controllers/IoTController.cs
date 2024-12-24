using Microsoft.AspNetCore.Mvc;
using WMSDemo.Models;
using WMSDemo.Services;

namespace WMSDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IoTController : ControllerBase
    {
        private readonly IoTService _iotService;

        public IoTController()
        {
            _iotService = new IoTService();
        }

        [HttpGet]
        public IActionResult GetAllIoTData()
        {
            var data = _iotService.GetAllIoTData();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddIoTData([FromBody] IoTData data)
        {
            _iotService.AddIoTData(data);
            return CreatedAtAction(nameof(GetAllIoTData), new { id = data.Id }, data);
        }
    }
}
