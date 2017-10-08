using Autofac;
using Autofac.Integration.WebApi;
using RefactionMe.Data;
using RefactionMe.Data.Infrastructure;
using RefactionMe.Data.Repositories;
using RefactionMe.Service;
using RefactionMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace RefactionMe.Api.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ProductContext>()
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerRequest();

            builder.RegisterType<ProductOptionRepository>()
                .As<IProductOptionRepository>()
                .InstancePerRequest();


            builder.RegisterType<ProductService>()
                .As<IProducService>()
                .InstancePerRequest();

            builder.RegisterType<ProductOptionService>()
                .As<IProductOptionService>()
                .InstancePerRequest();




            Container = builder.Build();

            return Container;
        }
        
    }
}