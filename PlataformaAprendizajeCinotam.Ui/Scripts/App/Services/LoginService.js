App.factory("$loginService", ["$http","$routeParams","$location","localStorageService", function ($http,$routeParams,$location,localStorageService) {
    var _usuario = {
        logged : false,
        nombre: "",
    };
    var _iniciarSesion = function (loginData,returnUrl) {
        var data = "grant_type=password&username=" + loginData.username + "&password=" + loginData.password;
        
        var response = $http.post(webApiEndPoint + "Token", data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } });
        response.then(function (d) {
            _usuario.logged = true;
            localStorageService.set("tokenData",{ token: d.data.access_token,userName:loginData.username});
            if (returnUrl == undefined) {

                $location.path("/Inicio")
            }
            else {

                $location.path(returnUrl);
            }
        });
    }
    var _registrar = function (loginData) {
        _cerrarSesion();
        var response = $http.post(webApiEndPoint + "api/Account/Register", loginData, {
            contentType:"application/json; charset=utf-8"
        });
        response.then(function (d) {
            console.log("Registro exitoso");
            $location.path("/Inicio");
        });
    }
    var _cerrarSesion = function () {
        localStorageService.remove("tokenData");
        _usuario.logged = false;
        _usuario.nombre = "";
        $location.path("/Inicio");
    }
    var _cargaInfo = function () {
        var logInfo = localStorageService.get("tokenData");
        if (logInfo) {
            _usuario = {};
            _usuario.logged = true;
            _usuario.nombre = logInfo.userName;
            return _usuario;
        }
        else {
            _usuario = {};
            _usuario.logged = false;
            _usuario.nombre = "";
            return _usuario;
        }
    }
    var loginServiceFactory = {};
    loginServiceFactory.usuario = _usuario;
    loginServiceFactory.iniciarSesion = _iniciarSesion;
    loginServiceFactory.registrar = _registrar;
    loginServiceFactory.cargaInfo = _cargaInfo;
    loginServiceFactory.cerrarSesion = _cerrarSesion;
    return loginServiceFactory;
}]);