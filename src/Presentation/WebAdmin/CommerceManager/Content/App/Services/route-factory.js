//Configure the routes
VirtoApp.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/index', {
        templateUrl: '/content/dashboard/index.html',
        controller: 'HomeController'
    });
    
    $routeProvider.when('/catalog', {
        templateUrl: '/content/catalog/index.html',
        controller: 'HomeController'
    });

    $routeProvider.otherwise({ redirectTo: '/index' });
}]);