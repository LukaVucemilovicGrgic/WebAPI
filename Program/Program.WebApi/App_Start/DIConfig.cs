using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Ajax.Utilities;
using Program.Repository;
using Program.Repository.Common;
using Program.Service;
using Program.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;

namespace Program.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<BuyerService>().As<IBuyerService>();
            builder.RegisterType<BuyerRepository>().As<IBuyerRepository>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}