'use strict';

/* Controllers */

var vcControllers = angular.module('vcApp.controllers', []);

vcControllers.controller('HomeController', ['$scope',
  function ($scope) {
      $scope.model = {};
  }]);