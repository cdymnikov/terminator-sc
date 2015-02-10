using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Terminator.Device.Input.Oculus
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHeadTrackerFactory>().ImplementedBy<HeadTrackerFactory>());
            container.Register(Component.For<IReaderFactory>().ImplementedBy<ReaderFactory>());
        }
    }
}
