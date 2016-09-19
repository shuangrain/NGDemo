var api = "/api";

app.factory("TaiwanAirService", function ($http, $q) {
    return {
        GetData: function (currentPage, pageSize) {
            var deferred = $q.defer();
            $http.get(api + '/api/TaiwanAir', { params: { CurrentPage: currentPage, PageSize: pageSize } })
                .success(deferred.resolve)
                .error(function (response, status) {
                    response.status = status;
                    return deferred.reject(response);
                });
            return deferred.promise;
        },

        GetTaiwanAir: function (id) {
            var deferred = $q.defer();
            $http.get(api + '/api/TaiwanAir', { params: { id: id } })
                .success(deferred.resolve)
                .error(function (response, status) {
                    response.status = status;
                    return deferred.reject(response);
                });
            return deferred.promise;
        },

        AddData: function (TaiwanAir) {
            var deferred = $q.defer();
            $http.post(api + '/api/TaiwanAir', TaiwanAir)
                .success(deferred.resolve)
                .error(function (response, status) {
                    response.status = status;
                    return deferred.reject(response);
                });
            return deferred.promise;
        },

        EditData: function (TaiwanAir) {
            var deferred = $q.defer();
            $http.put(api + '/api/TaiwanAir', TaiwanAir)
                .success(deferred.resolve)
                .error(function (response, status) {
                    response.status = status;
                    return deferred.reject(response);
                });
            return deferred.promise;
        },

        DeleteData: function (id) {
            var deferred = $q.defer();
            $http.delete(api + '/api/TaiwanAir?id=' + id)
                .success(deferred.resolve)
                .error(function (response, status) {
                    response.status = status;
                    return deferred.reject(response);
                });
            return deferred.promise;
        },
    };
});
