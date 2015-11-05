App.factory("$loginService", ["$http","$routeParams","$location","localStorageService", function ($http,$routeParams,$location,localStorageService) {
    var _usuario = {
        logged : false,
        nombre: "",
    };
    var _iniciarSesion = function (loginData) {
        var data = "grant_type=password&username=" + loginData.username + "&password=" + loginData.password;
        console.log(data);
        var response = $http.post(webApiEndPoint + "Token", data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } });
        response.then(function (d) {
            _usuario.logged = true;
            localStorageService.set("tokenData",{ token: d.data.access_token,userName:loginData.username});
            $location.path("/Cursos");
        });
    }
    var _registrar = function (loginData) {
        _cerrarSesion();
        var response = $http.post(webApiEndPoint + "api/Account/Register", loginData, {
            contentType:"application/json; charset=utf-8"
        });
        response.then(function (d) {
            console.log(d.data);
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
        console.log("cargado");
        var logInfo = localStorageService.get("tokenData");
        if (logInfo) {
            _usuario = {};
            _usuario.logged = true;
            _usuario.nombre = logInfo.userName;

            console.log(_usuario);
            return _usuario;
        }
        else {
            _usuario = {};
            _usuario.logged = false;
            _usuario.nombre = "";

            console.log(_usuario);
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