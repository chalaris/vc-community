'use strict';

/* Services */

var vcServices = angular.module('vcServices', ['ngResource']);

vcServices.factory('Shell', ['$resource',
  function ($resource) {
      return $resource('phones/:phoneId.json', {}, {
          query: { method: 'GET', params: { phoneId: 'phones' }, isArray: true }
      });
  }]);