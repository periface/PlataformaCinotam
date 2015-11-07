/// <reference path="../angular-route.min.js" />
/// <reference path="../angular.min.js" />
var App = angular.module("App", ["ngRoute", "angular-loading-bar", "LocalStorageModule", "ngAnimate"]);
App.factory("interceptorAutenticacion", interceptorAutenticacion);
var configuracion = function ($routeProvider, $httpProvider) {
    $routeProvider.when("/Inicio", {
        title: "Bienvenido",
        templateUrl: rutaArchivosWeb + "/Inicio/Index.html",
        controller: "paginaInicio",
        reglas:{
            rolesPermitidos:[],
            requiereSesion:false,
        },
    }).when("/Cursos", {
        title: "Cursos",
        templateUrl: rutaArchivosWeb + "/Cursos/Index.html",
        controller:"cursosController",
        reglas:{
            rolesPermitidos:[],
            requiereSesion:false,
        },
    }).when("/Registro", {
        title: "Iniciar Sesión",
        templateUrl: rutaArchivosWeb + "/Cuentas/Registro.html",
        controller: "registroController",
        reglas:{
            rolesPermitidos:[],
            requiereSesion:false,
        },
    }).when("/Login", {
        title: "Iniciar Sesión",
        templateUrl: rutaArchivosWeb + "/Cuentas/Login.html",
        controller: "loginController",
        caseInsensitiveMatch: true,
        reglas:{
            rolesPermitidos:[],
            requiereSesion:false,
        },
    }).when("/Login/:returnUrl", {
        title: "Iniciar Sesión",
        templateUrl: "Usuarios/Login.html",
        caseInsensitiveMatch: true,
        controller: "loginController",
        reglas:{
            rolesPermitidos:[],
            requiereSesion:false,
        },
    }).when("/CerrarSesion", {
        title: "Cerrar Sesión",
        reglas:{
            rolesPermitidos:[],
            requiereSesion:false,
        },
    }).otherwise("/Inicio");
    $httpProvider.interceptors.push("interceptorAutenticacion");
};
App.run(["$rootScope", "$route","$loginService","$location","interceptorRutasAuth", function ($rootScope, $route,$loginService,$location,interceptorRutasAuth) {
    //$loginService.cargaInfo();
    $rootScope.$on("$routeChangeSuccess", function (d) {
        document.title = $route.current.title;
    });
    $rootScope.$on("$routeChangeStart",function(event,next,current){
        var usuario = $loginService.cargaInfo();
        var reglas = next.reglas;
        var auth = interceptorRutasAuth.autoriza(reglas.requiereSesion,reglas.rolesPermitidos);

        if(!auth){
          $location.path("/login");
        }
    });
}]);
//Inyectamos para que la minificación no truene la aplicacion
configuracion.$inject = ["$routeProvider", "$httpProvider"];
App.config(configuracion);
