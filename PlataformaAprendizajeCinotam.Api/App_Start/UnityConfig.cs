using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using PlataformaAprendizajeCinotam.Api.Controllers;
using PlataformaAprendizajeCinotam.Api.Models;
using Servicios.Implementaciones;
using Servicios.Interfaces;
using System.Data.Entity;
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
            container.RegisterType<ICursoAdminService, CursoAdminServiceBase>();
            container.RegisterType<ICategoriaClientService, CategoriaClientServiceBase>();
            container.RegisterType<IImgService, ImgServiceBase>();
            container.RegisterType<ITextSevice, TextServiceBase>();
            //Account
            //Para user el accountController
            container.RegisterType<AccountController>(new InjectionConstructor());
            //Para poder usar identity
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}