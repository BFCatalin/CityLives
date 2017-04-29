angular.
  module('core.sensor').
  factory('Sensor', ['$resource',
    function ($resource) {
        return $resource('/api/sensor/:sId', {}, {
            get: {
                method: 'GET',
                params: { sId: '@sId' },
                isArray: false
            }
        });
    }
  ]);