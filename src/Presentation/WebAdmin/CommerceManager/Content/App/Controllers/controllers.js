'use strict';

/* Controllers */

var vcControllers = angular.module('vcApp.controllers', ['ngGrid']);

vcControllers.controller('HomeController', 
  function ($scope, $timeout, shell, notificationFactory) {
      $scope.items = {};    
      $scope.gridOptions = { data: 'items' };
      
      $scope.getItems = function() {
          $scope.items = shell.getDataSet();
      };
      
      $scope.init = function () {
          var success = function (data) {
              $scope.items = data.data;
          };

          var failure = function (data) {
              notificationFactory.error(data);
          };

          shell.getDataSet('catalog/items', success, failure);
      };

      $scope.init();
  });

