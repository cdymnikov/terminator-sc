using System;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Input.Joystick;

namespace Terminator.Tests
{
    [TestClass]
    public class When_reading_axis_value_without_interraction
    {
        private readonly Resolver _resolver = new Resolver();

        [TestMethod]
        public void Axis_value_is_centered()
        {
            var joystickProductName = ConfigurationManager.AppSettings["PhysicalJoystickTestDevice"].ToString();
            var joystickProductNumber = int.Parse(ConfigurationManager.AppSettings["PhysicalJoystickTestDeviceNumber"]);

            var reader = _resolver.Resolve<IReaderFactory>().Create(new Identifier(joystickProductName, joystickProductNumber));

            var axisValue = reader.ReadXAxis();

            Assert.IsTrue(32000 < axisValue && axisValue < 34000);
        }
    }
}
