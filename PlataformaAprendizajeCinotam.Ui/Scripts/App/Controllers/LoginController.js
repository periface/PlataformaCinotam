App.controller("loginController", ["$scope",  "$loginService", function ($scope, $loginService) {
    $scope.pageClass = "page-login";
    $scope.login = function (loginData) {
        userInfo = {};
        userInfo.username = loginData.username;
        userInfo.password = loginData.password;
        $loginService.iniciarSesion(userInfo);
    }
}]);