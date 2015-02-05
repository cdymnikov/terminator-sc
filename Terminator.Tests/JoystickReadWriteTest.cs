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
        [TestMethod]
        public void Axis_value_is_centered()
        {
            var directInput = new DirectInput();

            var guid = new DeviceNameResolver(directInput).Resolve(
                ConfigurationManager.AppSettings["PhysicalJoystickTestDevice"].ToString()).First();

            var joystick = new SharpDX.DirectInput.Joystick(directInput, guid);
            joystick.Properties.BufferSize = 128;
            joystick.Acquire();

            var reader = new Input.Joystick.Reader(joystick);

            var axisValue = reader.ReadXAxis();

            Assert.IsTrue(32000 < axisValue && axisValue < 34000);
        }
    }
}
