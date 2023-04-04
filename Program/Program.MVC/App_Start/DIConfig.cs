using Autofac.Integration.Mvc;
using Autofac;
using System.Web.Mvc;
using Program.Service.Common;
using Program.Repository;
using Program.Repository.Common;
using Program.DAL;
using Program.Service;
using System.Reflection;
using EFProgram.Repository;

namespace Program.Mvc.App_Start
{
    public class DIConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder(); //new instance of the dependency injection container.

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<BuyerService>().As<IBuyerService>();
            builder.RegisterType<EFBuyerRepository>().As<IBuyerRepository>();
            builder.RegisterType<BuyerContext>().AsSelf();

            var container = builder.Build();

            // Register the AutofacDependencyResolver with the DependencyResolver for MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
