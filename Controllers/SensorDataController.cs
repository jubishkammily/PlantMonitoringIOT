using Microsoft.AspNetCore.Mvc;
using PlantMonitorApi.Models;

namespace PlantMonitorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] SensorData data)
        {
            // Log incoming data to the console
            Console.WriteLine(
                $"[{DateTime.Now:HH:mm:ss}] " +
                $"Node={data.NodeId} " +
                $"Moisture={data.Moisture} " +
                $"Temp={data.Temperature} " +
                $"Humidity={data.Humidity} " +
                $"Light={data.Light}"
            );

            // Return a simple JSON acknowledgement
            return Ok(new { status = "received" });
        }
    }
}