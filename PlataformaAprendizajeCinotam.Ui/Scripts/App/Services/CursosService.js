App.factory("cursosRepository", ["$http", function ($http) {
    return {
        cargaCurso: function () {
            var url = webApiEndPoint + "api/Cursos/Curso/2"
            return $http.get(url);
        },
        cargaPublicaciones: function () {
            var url = webApiEndPoint + "api/Cursos/Todos";
            return $http.get(url);
        }
    };
}]);