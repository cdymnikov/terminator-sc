using Castle.Core;
using Castle.Windsor;

namespace Terminator
{
    public class Resolver
    {
        private readonly IWindsorContainer _container;

        public Resolver()
        {
            _container = new WindsorContainer();
            _container.Install(new Terminator.Installer());
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
