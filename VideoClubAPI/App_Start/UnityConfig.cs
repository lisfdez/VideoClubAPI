using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using VideoClubAPI.Models.EF;
using VideoClubAPI.Repositorio;

namespace VideoClubAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Registrar el entity
            container.RegisterType<VideoClubEntities>();

            //CONTENEDORES.REGISTERTYPE, SE DEBE HACER UNO POR CADA REPOSITORIO DE UNA DE LAS 2 FORMAS
            //container.RegisterType<Repositorio<ActoresPeliculasViewModel, Actores_Peliculas>>();
            //container.RegisterType<Repositorio<ClientesViewModel, Clientes>>();
            //container.RegisterType<Repositorio<ActoresViewModel, Actores>>();
            //container.RegisterType<Repositorio<PeliculasViewModel, Peliculas>>();
            container.RegisterType<RepositorioClientes>();
            container.RegisterType<RepositorioPeliculas>();
            container.RegisterType<RepositorioActores>();
            container.RegisterType<RepositorioActoresPeliculas>();
        }
    }
}