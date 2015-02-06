using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Terminator.Input.DirectX
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDeviceNameResolver>().ImplementedBy<DeviceNameResolver>());
            container.Register(Component.For<IReaderFactory>().ImplementedBy<ReaderFactory>());
        }
    }
}
