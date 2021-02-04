using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using CodeBase.Helpers;

namespace CodeBase
{
    public class AutofacConfig
    {
        static IContainer container;

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<SendEmail>().As<ISendEmail>();
            builder.Register(c => new SendEmail()).As<ISendEmail>();

            //var ioContainer = builder.Build();            
            container = builder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(ioContainer));
        }

        public static IContainer GetContainer() 
        {
            return container;
        }
    }


}
