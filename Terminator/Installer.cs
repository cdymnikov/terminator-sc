﻿using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Terminator
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new Terminator.Device.Installer());

            container.Register(Component.For<ILoopManager>().ImplementedBy<LoopManager>());
        }
    }
}
