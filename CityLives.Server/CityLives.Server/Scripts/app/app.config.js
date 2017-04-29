angular.
  module('CityLives').
  config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider.
            when('/dashboard', {
                template: '<dashboard></dashboard>'
            }).
            when('/sensor/:sId', {
                template: '<sensor></sensor>'
            }).
            when('/device/:deviceId', {
                template: '<device></device>'
            }).
            otherwise('/dashboard');
        //$locationProvider.html5Mode(true);
    }
  ]);