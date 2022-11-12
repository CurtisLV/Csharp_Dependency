using System;
using System.Collections.Generic;
using System.Linq;
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

            // registering the class
            // whenever one is looking for IBusinessLogic, BusinessLogic will be returned
            // respond with BusinessLogic whenever anyone needs IBusinessLogic item (new IBusinessLogic)
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            return builder.Build();
        }
    }
}
