App.controller("cursosController", ["$scope","cursosRepository", function ($scope, cursosRepository) {
    $scope.init = function () {
        $scope.curso = {};
        cursosRepository.cargaCurso().then(function (curso) {
            $scope.curso = curso;
            console.log(curso);
        });
    }
    $scope.init();
}]);
