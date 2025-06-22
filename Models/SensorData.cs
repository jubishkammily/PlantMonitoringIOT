using System.ComponentModel.DataAnnotations;

namespace PlantMonitorApi.Models
{
    public class SensorData : AuditableEntity
    {                       
        public string NodeId     { get; set; } = default!;
        public float  Moisture   { get; set; }
        public float  Temperature{ get; set; }
        public float  Humidity   { get; set; }
        public int    Light      { get; set; }

    }
}