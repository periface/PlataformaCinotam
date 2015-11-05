/// <reference path="../angular-route.min.js" />
/// <reference path="../angular.min.js" />
var App = angular.module("App", ["ngRoute", "angular-loading-bar", "LocalStorageModule", "ngAnimate"]);
App.factory("interceptorAutenticacion", interceptorAutenticacion);


var configuracion = function ($routeProvider, $httpProvider) {
    $routeProvider.when("/Inicio", {
        title: "Bienvenido",
        templateUrl: rutaArchivosWeb + "/Inicio/Index.html",
        controller: "paginaInicio"
    }).when("/Cursos", {
        title: "Cursos",
        templateUrl: rutaArchivosWeb + "/Cursos/Index.html"
    }).when("/Registro", {
        title: "Iniciar Sesión",
        templateUrl: rutaArchivosWeb + "/Cuentas/Registro.html",
        controller: "registroController"
    }).when("/Login", {
        title: "Iniciar Sesión",
        templateUrl: rutaArchivosWeb + "/Cuentas/Login.html",
        controller: "loginController"
    }).when("/Login/:returnUrl", {
        title: "Iniciar Sesión",
        templateUrl: "Usuarios/Login.html"
    }).otherwise("/Inicio");
    
    $httpProvider.interceptors.push("interceptorAutenticacion");
};


App.run(["$rootScope", "$route","$loginService", function ($rootScope, $route,$loginService) {
    $loginService.cargaInfo();
    $rootScope.$on("$routeChangeSuccess", function () {
        document.title = $route.current.title;
    });
    
}]);


configuracion.$inject = ["$routeProvider", "$httpProvider"];
App.config(configuracion);