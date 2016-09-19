app.controller("TaiwanAirCtrl", function ($scope, $location, TaiwanAirService) {
    //分頁參數
    $scope.maxSize = 5;
    $scope.totalRecords = 0;
    $scope.pageSize = 20;
    $scope.currentPage = 1;
    $scope.pageChanged = function () {
        GetData();
    };
    function GetData() {
        TaiwanAirService.GetData($scope.currentPage, $scope.pageSize).then(function (response) {
            $scope.totalRecords = response.Total;
            $scope.TaiwanAirs = response.Data;
        }, function (response) {
            if (response != null && response.Message != null) {
                toastr.error(response.Message, "Error");
            }
            else {
                toastr.error("系統錯誤 !!", "Error");
            }
        });
    }
    GetData();

    // 點選刪除時，給Service ID 並呼叫Web API
    $scope.delete = function (id) {
        TaiwanAirService.DeleteData(id).then(function (response, status) {
            toastr.success("", "Success");
            GetData();
        }, function (response) {
            if (response.status == 401) {
                toastr.info("請登入 !!", "Info");
                $("#login-modal").modal("show");
            } else {
                toastr.error("刪除失敗 !!", "Error");
            }
        })
    }
});
app.controller("TaiwanAirAddCtrl", function ($scope, TaiwanAirService) {
    $scope.submit = function () {
        TaiwanAirService.AddData($scope.TaiwanAir).then(function (response) {
            if (response != null) {
                if (response.Success == true) {
                    toastr.success(response.Message, "Success");
                    $scope.go("/TaiwanAir");
                } else {
                    toastr.warning(response.Message, "Warning");
                }
            }
            else {
                toastr.error("系統錯誤 !!", "Error");
            }
        }, function (response) {
            if (response != null) {
                toastr.error(response.Message, "Error");
            }
            else {
                toastr.error("系統錯誤 !!", "Error");
            }
        });
    };
});
app.controller("TaiwanAirEditCtrl", function ($scope, $routeParams, TaiwanAirService) {
    var id = $routeParams.id;
    TaiwanAirService.GetTaiwanAir(id).then(function (response) {
        if (response != null) {
            if (response.Success == true) {
                $scope.TaiwanAir = response.Data[0];
            } else {
                toastr.warning(response.Message, "Warning");
            }
        }
        else {
            toastr.error("系統錯誤 !!", "Error");
        }
    }, function (response) {
        if (response != null) {
            toastr.error(response.Message, "Error");
        }
        else {
            toastr.error("系統錯誤 !!", "Error");
        }
    });

    $scope.submit = function () {
        TaiwanAirService.EditData($scope.TaiwanAir).then(function (response) {
            if (response != null) {
                if (response.Success == true) {
                    toastr.success(response.Message, "Success");
                    $scope.go("/TaiwanAir");
                } else {
                    toastr.warning(response.Message, "Warning");
                }
            }
            else {
                toastr.error("系統錯誤 !!", "Error");
            }
        }, function (response) {
            if (response != null) {
                toastr.error(response.Message, "Error");
            }
            else {
                toastr.error("系統錯誤 !!", "Error");
            }
        });
    };
});
