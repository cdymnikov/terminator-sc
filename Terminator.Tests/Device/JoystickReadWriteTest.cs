using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Device;
using Terminator.Device.Input.DirectX;
using Terminator.Device.Input;
using Terminator.Device.Output;
using Terminator.Device.Output.Joystick;
using System.Threading;

namespace Terminator.Device
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

            var writer = new FrameWriter(
                new Dictionary<Output.Joystick.Identifier, IWriter>() { 
                    {output, _resolver.Resolve<IWriterFactory>().Create(output)} 
                });

            var reader = new FrameReader(
                new Dictionary<Input.DirectX.Identifier, IReader>() { 
                    {input, _resolver.Resolve<IReaderFactory>().Create(input)} 
                });

            WriteAndRead(writer, reader, input, output, Axis.X, 1);
            WriteAndRead(writer, reader, input, output, Axis.X, 0.5);
            WriteAndRead(writer, reader, input, output, Axis.X, 0);
            WriteAndRead(writer, reader, input, output, Axis.X, -0.5);
            WriteAndRead(writer, reader, input, output, Axis.X, -1);
        }

        private void WriteAndRead(FrameWriter writer, FrameReader reader, Input.DirectX.Identifier input, Output.Joystick.Identifier output, Axis axis, double value)
        {
            writer.Write(new Dictionary<Output.Joystick.Identifier, State> 
                { 
                    {output, new State() {Axis = new Dictionary<Axis, double> 
                        {
                            {axis, value}
                        } } }
                });
            Thread.Sleep(1);
            var actual = reader.Read()[input].Axis[axis];
            Assert.IsTrue(value <= actual + 0.001 && actual - 0.001 <= value);
        }
    }
}
