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
    
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            this.SensorMeasurements = new HashSet<SensorMeasurement>();
        }
    
        public long Id { get; set; }
        public Nullable<double> Lat { get; set; }
        public Nullable<double> Long { get; set; }
        public string Name { get; set; }
        public string SN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SensorMeasurement> SensorMeasurements { get; set; }
    }
}
