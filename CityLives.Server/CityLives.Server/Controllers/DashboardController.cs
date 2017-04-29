using CityLives.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityLives.Server.Controllers
{
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        [Route("")]
        [HttpGet]
        public Dashboard GetDashboard()
        {
            var dashboard = new Dashboard();
            using (var dbContext = new Entities())
            {
                dashboard.Sensors = dbContext.Sensors.Select(s => new SensorBasicViewModel()
                {
                    Id = s.Id,
                    SensorName = s.SensorName,
                    Description = s.Description,
                    MinValue = s.SensorMeasurements.Count > 0 ? s.SensorMeasurements.Min(sm => sm.Value) : 0,
                    MaxValue = s.SensorMeasurements.Count > 0 ? s.SensorMeasurements.Max(sm => sm.Value) : 0
                })
                .ToList();
            }
            return dashboard;
        }
    }
}
