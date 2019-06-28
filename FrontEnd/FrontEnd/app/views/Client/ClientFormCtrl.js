angular.module('mainApp')
    .controller('ClientFormCtrl', function ($scope, $routeParams, crudService, $location) {

        $scope.ClientObj;
        $scope.ClientIDToEdit;
        $scope.DataForTable = new Array();
        $scope.CurrentPage;
        $scope.TotalRecords;

        $scope.CallObj;
        $scope.CallArray = new Array();

        $scope.SaveFormData = function () {
            console.log("ClientToEdit", $scope.ClientIDToEdit);
            if ($scope.ClientIDToEdit) {
                //Edit
                $scope.ClientObj.ClientID = $scope.ClientIDToEdit;
                crudService.Update('client', $scope.ClientObj).then(function (res) {
                    console.log(res);
                    $location.path('/clientlist');
                });
            } else {
                // Add New
                crudService.InsertNew("client", $scope.ClientObj).then(function (res) {
                    console.log(res);
                    $location.path('/clientlist');
                });
            }
        }

        // Call Section Pagination

        SetPagination = function (recordsNumbers) {
            $scope.TotalRecords = new Array();
            for (i = 1; i <= Math.ceil(recordsNumbers / 10); i++) {
                $scope.TotalRecords.push(i);
            }
        }

        $scope.FetchNewPages = function (ele) {
            $scope.CurrentPage = ele;
            crudService.getPageResult('Call/GetPages/' + ele, $scope.ClientIDToEdit).then(function (response) {
                console.log("Try To Load Call");
                console.log(response.data);
                console.log(response.data.Results);
                $scope.DataForTable = response.data.Results;
                SetPagination(response.data.TotalRecords);
            });
        }

        // Save Call

        $scope.SaveCall = function(){
            if ($scope.ClientIDToEdit) {
                $scope.CallObj.ClientID = $scope.ClientIDToEdit;
                console.log($scope.CallObj);
                crudService.InsertNew('call', $scope.CallObj).then(function (res) {
                    $scope.CallObj.Employee = $scope.ClientObj.Employee;
                    $scope.CallObj.Client = $scope.ClientObj;
                    $scope.DataForTable.push(res.data);
                });
            } else {

                let tempObj = {};
                tempObj.Type = $scope.CallObj.Type;
                tempObj.Location = $scope.CallObj.Location;
                tempObj.Date = $scope.CallObj.Date;
                tempObj.Project = $scope.CallObj.Project;
                tempObj.EmployeeID = $scope.ClientObj.EmployeeID;
                
                $scope.ClientObj.Calls.push(tempObj);
                $scope.DataForTable.push(tempObj);

            }
        }

        init = function () {
            if ($routeParams.id) {
                $scope.ClientIDToEdit = $routeParams.id;
                crudService.getSingle('Client/GetClient', $routeParams.id).then(function (res) {
                    if (res.data) {
                        $scope.ClientObj = res.data;
                    } else {
                        $location.path('/clientlist');
                    }
                });
                $scope.FetchNewPages(1);
            } else {
                $scope.ClientObj = {};
                $scope.ClientObj.Calls = new Array();
            }
        }();

        $scope.back = function () {
            $location.path('/clientlist');
        }

    });
