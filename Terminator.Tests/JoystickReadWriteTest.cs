using System;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Input.Joystick;
using Terminator.Input;

namespace Terminator.Tests
{
    [TestClass]
    public class When_reading_axis_value_without_interraction
    {
        private readonly Resolver _resolver = new Resolver();

        [TestMethod]
        public void Axis_value_is_centered()
        {
            var input = (Input.Configuration)ConfigurationManager.GetSection("test/input");

            var reader = _resolver.Resolve<IReaderFactory>().Create(input.Joysticks["Physical Joystick"]);

            var axisValue = reader.ReadXAxis();

            Assert.IsTrue(32000 < axisValue && axisValue < 34000);
        }
    }
}
