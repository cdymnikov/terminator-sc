﻿using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using SharpDX.DirectInput;

namespace Terminator.Device.Output
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new Joystick.Installer());
            container.Install(new Mouse.Installer());
            container.Register(Component.For<IFrameWriter>().ImplementedBy<FrameWriter>());
        }
    }
}
