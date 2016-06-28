﻿using System.Web.Http;
using SwiftBookingTest.Core;
using SwiftBookingTest.CoreContracts;
using Ninject;
using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using SwiftBookingTest.Core.BusinessEngine;

namespace SwiftBookingTest.Web
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();

            kernel.Bind<IBusinessEngineFactory>().To<BusinessEngineFactory>();

            kernel.Bind<ISwiftBookingBusinessEngineUow>().To<SwiftBookingBusinessEngineUow>();

            kernel.Bind<ISwiftDemoUow>().To<SwiftDemoUow>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}