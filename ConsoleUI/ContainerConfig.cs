using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DemoLibrary;

namespace ConsoleUI
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            // registering the class
            // whenever one is looking for IBusinessLogic, BusinessLogic will be returned
            // respond with BusinessLogic whenever anyone needs IBusinessLogic item (new IBusinessLogic)
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            builder
                .RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
