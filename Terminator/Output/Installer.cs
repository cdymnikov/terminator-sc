using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using SharpDX.DirectInput;

namespace Terminator.Output
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new Terminator.Output.Joystick.Installer());
            container.Register(Component.For<IFrameWriter>().ImplementedBy<FrameWriter>());
        }
    }
}
