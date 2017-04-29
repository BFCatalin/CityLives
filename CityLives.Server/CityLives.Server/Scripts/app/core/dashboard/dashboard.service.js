angular.
  module('core.dashboard').
  factory('Dashboard', ['$resource',
    function ($resource) {
        return $resource('/api/dashboard', {}, {
            query: {
                method: 'GET',
                params: {},
                isArray: false
            }
        });
    }
  ]);