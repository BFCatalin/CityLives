angular.
  module('core.device').
  factory('Device', ['$resource',
    function ($resource) {
        return $resource('/api/device/:deviceId', {}, {
            get: {
                method: 'GET',
                params: { mId: '@deviceId' },
                isArray: false
            }
        });
    }
  ]);