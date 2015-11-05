App.controller("menuPrincipal", ["$scope","$loginService", function ($scope,$loginService) {
    $scope.usuario = $loginService.cargaInfo();
    console.log($scope.usuario);
    $scope.LogOut = function () {
        $loginService.cerrarSesion();
    }
}]);