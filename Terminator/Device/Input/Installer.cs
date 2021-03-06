﻿using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using SharpDX.DirectInput;

namespace Terminator.Device.Input
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new DirectX.Installer());
            container.Install(new Oculus.Installer());
            container.Register(Component.For<DirectInput>().ImplementedBy<DirectInput>());
        }
    }
}
