'use strict'

// Declare app level module which depends on filters, and services
angular.module('vcApp', ['vcApp.controllers', function () {
}])
//Configure the routes
.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/index', {
        templateUrl: '/content/core/index.html',
        controller: 'HomeController'
    });

    $routeProvider.otherwise({ redirectTo: '/index' });
}]);