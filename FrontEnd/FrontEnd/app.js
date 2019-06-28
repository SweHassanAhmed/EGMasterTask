var application = angular.module('mainApp', ['ngRoute']);

// Routing Config
application.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/clientlist', {
            templateUrl: 'app/views/Client/ClientList.html',
            controller: 'ClientListCtrl'
        })
        .when('/clientedit/:id', {
            templateUrl: 'app/views/Client/Clientform.html',
            controller: 'ClientFormCtrl'
        })
        .when('/clientadd', {
            templateUrl: 'app/views/Client/Clientform.html',
            controller: 'ClientFormCtrl'
        })


        .when('/', {
            redirectTo: '/clientlist'
        })
        .otherwise({
            redirectTo: '/clientlist'
        });
    //$locationProvider.html5Mode(true);

});

// Main Component
application.controller('myCtrl', function ($scope) {
    console.log('Start ...');
});

