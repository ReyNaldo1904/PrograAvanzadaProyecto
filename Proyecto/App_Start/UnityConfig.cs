using System;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Proyecto.Controllers;
using Proyecto.Models;
using Proyecto.Repository;
using Proyecto.Services;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Microsoft.AspNet.Identity.Owin;

namespace Proyecto
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

           
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            //intento de resolver el problema con identity y unity
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            //Inyección de dependencias para los controllers
            container.RegisterType<IProductoRepository, ProductoRepository>();
            container.RegisterType<IProductoService, ProductoService>();
            container.RegisterType<ICarritoRepository, CarritoRepository>();
            container.RegisterType<ICarritoService, CarritoService>();
            container.RegisterType<IHistorialCompraService, HistorialCompraService>();
            container.RegisterType<IHistorialComprasRepository, HistorialCompraRepository>();

            container.RegisterType<IResenasRepository, ResenasRepository>();
            container.RegisterType<IResenasService, ResenasService>();

            container.RegisterType<IPedidoService, PedidoService>();
            container.RegisterType<IPedidoRepository, PedidoRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}