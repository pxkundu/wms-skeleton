namespace WMSDemo.Models
{
    public class IoTData
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string MetricType { get; set; } // e.g., Temperature, Sound, Air Quality
        public double MetricValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
