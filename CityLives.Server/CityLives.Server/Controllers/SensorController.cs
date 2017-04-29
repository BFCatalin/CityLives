using CityLives.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityLives.Server.Controllers
{
    [RoutePrefix("api/sensor")]
    public class SensorController : ApiController
    {
        [Route("{sensorId}")]
        [HttpGet]
        public SensorViewModel Get(int sensorId)
        {
            SensorViewModel sensor = null;
            var now = DateTime.Now;
            using (var dbContext = new Entities())
            {
                var dbSensor =  dbContext.Sensors.FirstOrDefault(s=>s.Id == sensorId);
                var sensorMeasurements = dbSensor.SensorMeasurements.Where(sm => sm.MeasureDate > now.AddDays(-5));
                if(dbSensor != null){
                    sensor = new SensorViewModel()
                    {
                        Id = dbSensor.Id,
                        SensorName = dbSensor.SensorName,
                        Description = dbSensor.Description,
                        MinValue = sensorMeasurements.Any() ? dbSensor.SensorMeasurements.Min(sm => sm.Value) : 0,
                        MaxValue = sensorMeasurements.Any() ? dbSensor.SensorMeasurements.Max(sm => sm.Value) : 0,
                        Measurements = sensorMeasurements.Select(sm => new SensorMeasurementsViewModel()
                        {
                            DeviceId = sm.DeviceId,
                            Id = sm.Id,
                            Lat = sm.Lat,
                            Long = sm.Long,
                            MeasureDate = sm.MeasureDate,
                            SensorId = sm.SensorId,
                            Value = sm.Value
                        })
                    };
                }
            }
            return sensor;
        }
    }
}
