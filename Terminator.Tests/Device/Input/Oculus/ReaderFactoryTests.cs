using System.Reflection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Device;
using Terminator.Device.Input;
using Terminator.Device.Input.Oculus;
using SharpOVR;
using SharpDX;

namespace Terminator.Device.Input.Oculus
{
    [TestClass]
    public class When_creating_a_reader
    {
        [TestMethod]
        public void Reader_correctly_combines_eye_values()
        {
            var input = ((Input.Configuration)ConfigurationManager.GetSection("test/input")).Oculi["Oculus DK2"];
            var tracker = new FakeTracker();
            var resolver = new Resolver(x => x.Register(Castle.MicroKernel.Registration.Component.For<IHeadTrackerFactory>().Instance(new FakeTrackerFactory(tracker))));
            var reader = resolver.Resolve<IReaderFactory>().Create(input);

            tracker.Left = new PoseF
                {
                    Orientation = new Quaternion(1, 2, 3, 4),
                    Position = new Vector3(4, 5, 6)
                };

            tracker.Right = new PoseF
                {
                    Orientation = new Quaternion(1, 2, 3, 4),
                    Position = new Vector3(7, 8, 9)
                };

            var state = reader.Read();
            Assert.AreEqual(5.5, state.Axis[Axis.X], 0.01);
            Assert.AreEqual(6.5, state.Axis[Axis.Y], 0.01);
            Assert.AreEqual(7.5, state.Axis[Axis.Z], 0.01);
            Assert.AreEqual(1, state.Axis[Axis.XRot], 0.01);
            Assert.AreEqual(2, state.Axis[Axis.YRot], 0.01);
            Assert.AreEqual(3, state.Axis[Axis.ZRot], 0.01);
        }
    }
}

