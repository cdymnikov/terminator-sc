using System;
using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Terminator
{
    public class Resolver
    {
        private readonly IWindsorContainer _container;

        public Resolver() : this(x => { })
        {
        }

        public Resolver(Action<IWindsorContainer> additional)
        {
            _container = new WindsorContainer();
            additional(_container);
            _container.Install(new Terminator.Installer());
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
