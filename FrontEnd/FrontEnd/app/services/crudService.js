angular.module('mainApp')
    .service('crudService', function ($http) {

        var baseUrl = "http://localhost:63000/api/";

        // Function With GET Verb
        this.getList = function (apiName) {
            return $http({
                method: 'GET',
                url: baseUrl + apiName
            });
        }

        this.getPageResult = function (apiName, PageNumber) {
            return $http({
                method: 'GET',
                url: baseUrl + apiName + '/' + PageNumber
            });
        }

        this.getSingle = function (apiName, id) {
            return $http({
                method: 'GET',
                url: baseUrl + apiName + '/' + id 
            });
        }

        // Function With POST Verb 
        this.InsertNew = function (apiName, objData) {
            return $http({
                method: 'POST',
                url: baseUrl + apiName,
                data: objData,
                headers: { 'Content-Type': 'application/json' }
            });
        }

        // Functions With PUT Verb
        this.Update = function (apiName, objData) {
            return $http({
                method: 'PUT',
                url: baseUrl + apiName,
                data: objData,
                headers: { 'Content-Type': 'application/json' }
            });
        }

        //Functions With Delete Verb
        this.Delete = function (apiName, id) {
            return $http({
                method: 'DELETE',
                url: baseUrl + apiName + '/' + id
            });
        }

    });