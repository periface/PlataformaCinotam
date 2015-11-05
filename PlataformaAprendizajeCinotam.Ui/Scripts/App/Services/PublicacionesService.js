App.factory("publicacionesRepository", ["$http", function ($http) {
    return {
        cargaPublicacion: function () {
            var url = webApiEndPoint + "api/Cursos/Curso/1"
            return $http.get(url);
        },
        cargaPublicaciones: function () {
            var url = webApiEndPoint + "api/Cursos/Todos";
            return $http.get(url);
        }
    };
}]);