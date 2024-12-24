using System.Collections.Generic;
using System.Linq;
using WMSDemo.Models;

namespace WMSDemo.Services
{
    public class IoTService
    {
        private readonly List<IoTData> _iotDataStore;

        public IoTService()
        {
            // Initialize with mock data
            _iotDataStore = new List<IoTData>
            {
                new IoTData { Id = 1, DeviceId = "Sensor1", MetricType = "Temperature", MetricValue = 22.5, Timestamp = DateTime.Now.AddMinutes(-10) },
                new IoTData { Id = 2, DeviceId = "Sensor2", MetricType = "Sound", MetricValue = 55.0, Timestamp = DateTime.Now.AddMinutes(-5) }
            };
        }

        public List<IoTData> GetAllIoTData() => _iotDataStore;

        public void AddIoTData(IoTData data)
        {
            data.Id = _iotDataStore.Max(d => d.Id) + 1; // Auto-generate ID
            _iotDataStore.Add(data);
        }
    }
}
