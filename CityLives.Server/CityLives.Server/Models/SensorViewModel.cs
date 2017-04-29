using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityLives.Server.Models
{
    public class SensorViewModel : SensorBasicViewModel
    {
        public IEnumerable<SensorMeasurementsViewModel> Measurements { get; set; }
    }
}