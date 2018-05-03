using SimpleInjector;
using System;

namespace Upecito.Bot
{
    public class SomeServiceFactory : ISomeServiceFactory
    {
        private readonly Container container;

        // Here we depend on Container, which is fine, since
        // we're inside the composition root. The rest of the
        // application knows nothing about a DI framework.
        public SomeServiceFactory(Container container)
        {
            this.container = container;
        }

        public T Create<T>() where T : class
        {
            // Do what ever we need to do here. For instance:
            return container.GetInstance<T>();
        }
    }
}