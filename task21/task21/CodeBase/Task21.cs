using Autofac;
using CodeBase.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;

namespace CodeBase
{
    public class Task21 : UmbracoApplication
    {
        public override void Init()
        {
            base.Init();
            Application_Start();
        }
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            Task21.AddLog<Task21>("application start has been executed!", null, 0);
        }

        public static T Resolve<T>()
        {
            return AutofacConfig.GetContainer().Resolve<T>();
        }

        public static IEmailSender Email => Resolve<IEmailSender>();

        public static string AddLog<T>(string message, Exception ex = null, int level = 0)
        {
            return Task21.Resolve<ILogHelper>().AddLog<T>(message, ex, level);
        }
    }
}
