var app = angular.module('NGDemo', ['ngRoute', 'ui.bootstrap']);
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            controller: 'TaiwanAirCtrl',
            templateUrl: '/TaiwanAir/Index'
        })
        .when('/TaiwanAir', {
            controller: 'TaiwanAirCtrl',
            templateUrl: '/TaiwanAir/Index'
        })
        .when('/TaiwanAir/Add', {
            controller: 'TaiwanAirAddCtrl',
            templateUrl: '/TaiwanAir/View'
        })
        .when('/TaiwanAir/Edit/:id', {
            controller: 'TaiwanAirEditCtrl',
            templateUrl: '/TaiwanAir/View'
        });
    //.otherwise({
    //    controller: 'DashBoardCtrl',
    //    templateUrl: viewBase + 'DashBoardApp/Index.html'
    //});
}]);
app.run(function ($rootScope, $location, AccountService) {
    //讀取完畢
    $rootScope.$on('$viewContentLoaded', function () {
        $rootScope.IsLoad = false;
        $("#content").show();
    });
    //讀取之前
    $rootScope.$on('$locationChangeStart', function () {
        $rootScope.IsLoad = true;
        $("#content").hide();
    });
    $rootScope.go = function (path) {
        $location.path(path);
    };
    $rootScope.login = function () {
        AccountService.Login($rootScope.Login).then(function (response) {
            $rootScope.Login = null;
            toastr.success("", "Success");
            $("#login-modal").modal("hide");
        }, function (response) {
            if (response != null && response.Message != null) {
                toastr.error(response.Message, "Error");
            }
            else {
                toastr.error("系統錯誤 !!", "Error");
            }
        });
    };
});

//temp account service

var api = "/api";

app.factory("AccountService", function ($http, $q) {
    return {
        Login: function (Login) {
            var deferred = $q.defer();
            $http.post(api + '/api/Account/Login', Login)
                .success(deferred.resolve)
                .error(function (response, status) {
                    response.status = status;
                    return deferred.reject(response);
                });
            return deferred.promise;
        }
    };
});

