using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityLives.Server.Models
{
    public class SensorBasicViewModel
    {
        public int Id { get; set; }

        public string SensorName { get; set; }

        public string Description { get; set; }

        public double MinValue { get; set; }

        public double MaxValue { get; set; }
    }
}