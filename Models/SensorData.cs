namespace PlantMonitorApi.Models
{
    public class SensorData
    {
        public string NodeId     { get; set; }
        public float  Moisture   { get; set; }
        public float  Temperature{ get; set; }
        public float  Humidity   { get; set; }
        public int    Light      { get; set; }
    }
}