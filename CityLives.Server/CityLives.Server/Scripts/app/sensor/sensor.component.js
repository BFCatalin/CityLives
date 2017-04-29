angular.
  module('CityLives').
  component('sensor', {
      templateUrl: 'scripts/app/sensor/sensor.template.html',
      controller: function SensorController($scope, $routeParams, Sensor) {

          $scope.sensor = Sensor.get({ sId: $routeParams.sId });

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


          map = new google.maps.Map(document.getElementById('map'), {
              zoom: 13,
              center: { lat: 46.7665509, lng: 23.5912164 }
          });
      }
  })
//.directive('googleMap', function ($rootScope, lazyLoadApi) {

//    return {
//        restrict: 'CA', // restrict by class name
//        scope: {
//            mapId: '@id', // map ID
//            lat: '@', // latitude
//            long: '@' // longitude
//        },
//        link: function (scope, element, attrs) {
//            var location = null;
//            var map = null;
//            var mapOptions = null;

//            // Check if latitude and longitude are specified
//            if (angular.isDefined(scope.lat) && angular.isDefined(scope.long)) {
//                // Loads google map script
//                lazyLoadApi.then(initializeMap)
//            }

//            // Initialize the map
//            function initializeMap() {
//                location = new google.maps.LatLng(scope.lat, scope.long);

//                mapOptions = {
//                    zoom: 12,
//                    center: location
//                };

//                map = new google.maps.Map(element[0], mapOptions);

//                new google.maps.Marker({
//                    position: location,
//                    map: map,
//                });
//            }
//        }
//    };
//}).service('lazyLoadApi', function lazyLoadApi($window, $q) {
//    function loadScript() {
//        console.log('loadScript')
//        // use global document since Angular's $document is weak
//        var s = document.createElement('script')
//        s.src = '//maps.googleapis.com/maps/api/js?key=AIzaSyDzZ-6ej2eh6qlvzhEfmaTHkkrYdie02Qs&callback=initMap'
//        document.body.appendChild(s)
//    }
//    var deferred = $q.defer()

//    $window.initMap = function () {
//        deferred.resolve()
//    }

//    if ($window.attachEvent) {
//        $window.attachEvent('onload', loadScript)
//    } else {
//        $window.addEventListener('load', loadScript, false)
//    }

//    return deferred.promise
//});