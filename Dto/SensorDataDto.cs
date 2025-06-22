namespace PlantMonitorApi.Dto
{
    public class SensorDataDto : AutitableEntityDto
    {
        public string NodeId { get; set; } = default!;
        public float Moisture { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public int Light { get; set; }
    }
}
