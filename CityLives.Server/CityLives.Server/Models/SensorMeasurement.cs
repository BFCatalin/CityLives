//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CityLives.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SensorMeasurement
    {
        public long Id { get; set; }
        public int SensorId { get; set; }
        public long DeviceId { get; set; }
        public double Value { get; set; }
        public System.DateTime MeasureDate { get; set; }
        public Nullable<double> Lat { get; set; }
        public Nullable<double> Long { get; set; }
    
        public virtual Sensor Sensor { get; set; }
        public virtual Device Device { get; set; }
    }
}
