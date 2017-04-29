angular.
  module('CityLives').
  component('dashboard', {
      templateUrl: 'scripts/app/dashboard/dashboard.template.html',
      controller: function DashboardController($scope, Dashboard) {
          $scope.dashboard = Dashboard.get();

          $scope.getSensorMeasureUnit = function (sensorId) {
              var unit = "";
              switch (sensorId) {
                  case 1:
                      unit = "<sup>o</sup>C";
                      break;
                  case 2:
                      unit = "CO<sub>2</sub>";
                      break;
                  case 3:
                      unit = "UV";
                      break;
                  case 4:
                      unit = "dBA";
                      break;
                  case 5:
                      unit = "kPa";
                      break;
                  case 6:
                      unit = "L/m<sup>2</sup>";
                      break;
              }
              return unit;
          }

          $scope.showSensorMinMax = function (sensor) {
              return sensor.minValue != 0 && sensor.minValue != 0;
          }

          $scope.viewSensor = function (sensor) {
              window.location = "#!/sensor/" + sensor.id;
          }
      }
  });