angular.
  module('CityLives').
  component('deviceDetail', {
      templateUrl: 'scripts/app/device/device-detail.template.html',
      controller: function DeviceController($scope, Device) {
          var self = this;
          self.dashboard = Dashboard.get();
      }
  });