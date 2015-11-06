App.controller("cursosController", ["$scope","cursosRepository", function ($scope, cursosRepository) {
    console.log("Carga");
    $scope.init = function () {
        $scope.curso = {};
        cursosRepository.cargaCurso().success(function (curso) {
            $scope.curso = curso;
            console.log(curso);
        });
    }
    $scope.init();
}]);