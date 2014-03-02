'use strict';

/* Services */
var vcServices = angular.module('vcApp.Services', ['ngResource']);

vcServices.factory('shell',
  function ($resource, $timeout) {
      return {
          getDataSet: function (url, success, fail) {
              var dataSetPromise = $resource(url, {}, {
                  query: { method: 'GET', isArray: false }
              });

              (function load() {
                  dataSetPromise.get((function (data) {
                      success(data);
                      
                      // setup next polling
                      var normal = data.pollingInterval;
                      $timeout(load, normal);
                      
                  }), function (data) {
                      fail(data);
                  });
              })();
          }
      };

  });