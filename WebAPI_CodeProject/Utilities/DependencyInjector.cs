using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace WebAPI_CodeProject.Utilities
{
    public class DependencyInjector
    {
        private static readonly UnityContainer container = new UnityContainer();
        
        public static void Register<I, T>() where T : I
        {
            
            container.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }
        public static void InjectStub<I>(I instance)
        {
           container.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }
        public static T Retrieve<T>()
        {
            return container.Resolve<T>();
        }
    }
}