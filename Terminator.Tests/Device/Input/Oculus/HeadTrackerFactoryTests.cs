using System.Reflection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Device;
using Terminator.Device.Input;
using Terminator.Device.Input.Oculus;
using System.Threading;
using System.Windows;
using SharpOVR;

namespace Terminator.Device.Input.Oculus
{
    [TestClass]
    public class When_creating_a_headtracker
    {
        static When_creating_a_headtracker()
        {
            var manager = new AppDomainManager();
            var entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            entryAssemblyfield.SetValue(manager, Assembly.GetCallingAssembly());

            var domainManagerField = AppDomain.CurrentDomain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
            domainManagerField.SetValue(AppDomain.CurrentDomain, manager);
        }
        
        private readonly Resolver _resolver = new Resolver();

        [TestMethod]
        public void Head_tracker_produces_sane_values()
        {          
            var input = ((Input.Configuration)ConfigurationManager.GetSection("test/input")).Oculi["Oculus DK2"];
            var tracker = _resolver.Resolve<IHeadTrackerFactory>().Create(input);

            AssertNotZero(tracker.ReadLeftEye());
            AssertNotZero(tracker.ReadRightEye());
        }

        private void AssertNotZero(PoseF position)
        {
            Assert.AreNotEqual(0, position.Orientation.W);
            Assert.AreNotEqual(0, position.Orientation.X);
            Assert.AreNotEqual(0, position.Orientation.Y);
            Assert.AreNotEqual(0, position.Orientation.Z);
            Assert.AreNotEqual(0, position.Position.X);
            Assert.AreNotEqual(0, position.Position.Y);
            Assert.AreNotEqual(0, position.Position.Z);
        }
    }
}

