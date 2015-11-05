App.controller("Publicaciones", ["$scope","publicacionesRepository", function ($scope, publicacionesRepository) {
    console.log("Carga");
    $scope.init = function () {
        $scope.publicacion = {};
        publicacionesRepository.cargaPublicacion().success(function (publicacion) {
            $scope.publicacion = publicacion;
        });
    }
    $scope.init();
}]);