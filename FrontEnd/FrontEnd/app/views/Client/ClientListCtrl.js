angular.module('mainApp')
    .controller('ClientListCtrl', function ($scope, $routeParams, crudService, $location) {

        $scope.TotalRecords;
        $scope.CurrentPage;
        $scope.DataForTable;

        $scope.checkBoxSection = false;

        $scope.NameCheck = true;
        $scope.AddressCheck = true;
        $scope.PhoneCheck = true;
        $scope.EmailCheck = true;
        $scope.SourceCheck = true;
        $scope.ClassificationCheck = true;
        $scope.MobileCheck = true;
        $scope.EmployeeNameCheck = true;

        SetPagination = function (recordsNumbers) {
            $scope.TotalRecords = new Array();
            for (i = 1; i <= Math.ceil(recordsNumbers / 10); i++) {
                $scope.TotalRecords.push(i);
            }
        }

        $scope.FetchNewPages = function (ele) {
            $scope.CurrentPage = ele;
            crudService.getPageResult('Client/GetPages', ele).then(function (response) {
                console.log(response.data);
                console.log(response.data.Results);
                $scope.DataForTable = response.data.Results;
                SetPagination(response.data.TotalRecords);
            });
        }

        init = function () {
            $scope.FetchNewPages(1);
        }();


        $scope.DeleteClient = function (clientID) {
            crudService.Delete('Client', clientID).then(function (res) {
                $scope.FetchNewPages($scope.CurrentPage);
            });
        }

        $scope.EditClient = function (clientID) {
            $location.path('/clientedit/' + clientID);
        }

        $scope.AddClient = function () {
            $location.path('/clientadd');
        }

        $scope.ToggleSettings = function () {
            $scope.checkBoxSection = !$scope.checkBoxSection;
        }

        $scope.ReloadTable = function () {
            $scope.FetchNewPages($scope.CurrentPage);
        }

    });
