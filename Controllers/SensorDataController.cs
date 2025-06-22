using Microsoft.AspNetCore.Mvc;
using PlantMonitorApi.Dto;
using PlantMonitorApi.Models;
using PlantMonitorApi.Service;

namespace PlantMonitorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController(ISensorDataService sensorDataService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SensorDataDto data)
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

            await sensorDataService.StoreAsync(data);

            // Return a simple JSON acknowledgement
            return Ok(new { status = "received" });
        }

        [HttpGet]
        public async Task<IEnumerable<SensorDataDto>> GetAll()
        {
            return await sensorDataService.GetAllAsync();
        }
    }
}