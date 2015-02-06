using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using SharpDX.DirectInput;

namespace Terminator.Input
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new Terminator.Input.Joystick.Installer());
            container.Register(Component.For<DirectInput>().ImplementedBy<DirectInput>());
        }
    }
}
