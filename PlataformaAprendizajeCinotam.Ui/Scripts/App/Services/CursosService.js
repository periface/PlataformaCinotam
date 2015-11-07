App.factory("cursosRepository", ["$http","$q", function ($http,$q) {
    return {
        cargaCurso: function () {
            var deferred = $q.defer();
            var promise = deferred.promise;
            var url = webApiEndPoint + "api/Cursos/Curso/2"
            $http.get(url).success(function(data){
              deferred.resolve(data);
            }).error(function(err){
              deferred.reject(err);
            });
            return promise;
        },
        cargaPublicaciones: function () {
            var url = webApiEndPoint + "api/Cursos/Todos";
            return $http.get(url);
        }
    };
}]);
