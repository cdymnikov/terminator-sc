using System;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Input.Joystick;
using Terminator.Input;
using Terminator.Output;
using Terminator.Output.Joystick;

namespace Terminator.Tests
{
    [TestClass]
    public class When_writing_and_reading_axis_value
    {
        private readonly Resolver _resolver = new Resolver();

        [TestMethod]
        public void The_values_match()
        {
            var input = ((Input.Configuration)ConfigurationManager.GetSection("test/input")).Joysticks["Virtual Joystick Input"];
            var output = ((Output.Configuration)ConfigurationManager.GetSection("test/output")).Joysticks["Virtual Joystick Output"];

            var writer = _resolver.Resolve<IWriterFactory>().Create(output);
            var reader = _resolver.Resolve<IReaderFactory>().Create(input);

            writer.WriteXAxis(1337);
            Assert.AreEqual(1337, reader.ReadXAxis());

            writer.WriteXAxis(2338);
            Assert.AreEqual(2338, reader.ReadXAxis());
        }
    }
}
