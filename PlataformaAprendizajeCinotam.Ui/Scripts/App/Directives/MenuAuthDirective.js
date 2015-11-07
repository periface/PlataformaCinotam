//Utilizarse si se requieren roles para ocultar elementos del dom (DOOM!!!)
App.directive("acceso",["interceptorRutasAuth","$loginService",function(interceptorRutasAuth,loginService){
  return{
    restrict: "A",
    link: function(scope,elemento,attributos){

      var hacerVisible = function(){
        elemento.removeClass("hidden");
      },
      hacerInvisible = function(){
        elemento.addClass("hidden");
      },
      determinarVisibilidad = function(reset){
        var resultado;
        if(reset){
          hacerVisible();
        }
        resultado = interceptorRutasAuth.autoriza(true,roles);
        if(resultado){
          hacerVisible();
        }
        else{
          hacerInvisible();
        }
      },
      roles = attributos.acceso.split(",");
      scope.$watch(loginService.usuario,function(){
        determinarVisibilidad(true,roles);
      });
      if(roles.length>0){
        determinarVisibilidad(true);
      }
    }
  }
}]);
