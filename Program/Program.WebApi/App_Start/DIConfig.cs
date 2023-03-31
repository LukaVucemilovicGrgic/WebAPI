using Autofac;
using Autofac.Integration.WebApi;
using EFProgram.Repository;
using Microsoft.Ajax.Utilities;
using Program.Repository;
using Program.Repository.Common;
using Program.Service;
using Program.Service.Common;
using Program.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using Program.DAL;

namespace Program.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();       //new instance of the dependency injection container.

            //register all of the Web API controllers in the current assembly with the container.

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //The RegisterType method is called on the builder instance to register two types,
            //BuyerService and BuyerRepository, with the container. The As method is used to
            //specify the interfaces that these types implement (IBuyerService and IBuyerRepository, respectively).

            builder.RegisterType<BuyerService>().As<IBuyerService>();
            builder.RegisterType<EFBuyerRepository>().As<IBuyerRepository>();
            builder.RegisterType<BuyerContext>().AsSelf();

            //build the container

            var container = builder.Build();

            //The DependencyResolver property of the GlobalConfiguration.Configuration instance is set to a new
            //instance of AutofacWebApiDependencyResolver, passing in the container instance as a parameter.

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}

//Overall, this code sets up the dependency injection container and registers several types with it, including Web API controllers,
//a service class (BuyerService), and a repository class (BuyerRepository). Finally, it configures the Web API dependency resolver
//to use the Autofac container.