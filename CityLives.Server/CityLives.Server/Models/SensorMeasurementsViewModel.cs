using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityLives.Server.Models
{
    public class SensorMeasurementsViewModel
    {
        public long Id { get; set; }

        public int SensorId { get; set; }

        public long DeviceId { get; set; }

        public double Value { get; set; }

        public System.DateTime MeasureDate { get; set; }

        public double? Lat { get; set; }

        public double? Long { get; set; }
    }
}
