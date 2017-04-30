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
                var dbSensor = dbContext.Sensors.FirstOrDefault(s => s.Id == sensorId);
                var sensorMeasurements = dbSensor.SensorMeasurements.Where(sm => sm.MeasureDate > now.AddDays(-5));
                if (dbSensor != null)
                {
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

        [Route("{data}")]
        [HttpPost]
        public bool Post(SensorViewModel data)
        {

            return true;
        }
        [Route("generateData")]
        [HttpGet]
        public bool GenerateData()
        {
            var now = DateTime.Now;
            using (var dbContext = new Entities())
            {
                var devices = new List<Device>()
                {
                    new Device(){ Name="Piata Unirii - Eroilor", Lat = 46.769304, Long =  23.590888 },
                    new Device(){ Name="Piata Unirii - Ferdinand", Lat = 46.771023, Long =  23.589949 },
                    new Device(){ Name="Memorandumului - Ioan Ratiu", Lat = 46.769770, Long =  23.587349 },
                    new Device(){ Name="Ioan Ratiu - Episcop Ioan Bob", Lat = 46.768794, Long =  23.588102 },
                };
                for (int i = 0; i < 3600; i++)
                {
                    var sensorData = new SensorMeasurement()
                    {
                        Device = devices[0],
                        Lat = devices[0].Lat,
                        Long = devices[0].Long,
                        MeasureDate = now.AddSeconds(i),
                        SensorId = 1,
                        Value = 22
                    };

                    dbContext.SensorMeasurements.Add(sensorData);
                    dbContext.SaveChanges();
                }
            }
            return true;
        }

        private double[] TemperatatureVariationInOneHour(double baseValue, DateTime baseDayTime)
        {
            var random = new Random();
            var maxDelta = 0.0;
            var values = new double[3600];
            if (baseDayTime.TimeOfDay.Hours > 10 && baseDayTime.TimeOfDay.Hours < 15) //rapid variation in 1 hour
            {
                maxDelta = 3.0 / 720;
            }
            else
            {
                maxDelta = 1.5 / 720;
            }
            values[0] = baseValue;
            for (int i = 1; i < 3600; i++)
            {
                var val = values[i - 1] + (random.NextDouble() * maxDelta);
            }

            return values;
        }
    }
}
