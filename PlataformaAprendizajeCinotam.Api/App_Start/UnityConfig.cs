using Microsoft.Practices.Unity;
using Servicios.Implementaciones;
using Servicios.Interfaces;
using System.Web.Http;
using Unity.WebApi;

namespace PlataformaAprendizajeCinotam.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICursoClientService, CursoClientServiceBase>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}