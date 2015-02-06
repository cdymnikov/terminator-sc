using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Device;
using Terminator.Input.DirectX;
using Terminator.Input;
using Terminator.Output;
using Terminator.Output.Joystick;
using System.Threading;

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

            var writer = new FrameWriter(
                new Dictionary<Output.Joystick.Identifier, IWriter>() { 
                    {output, _resolver.Resolve<IWriterFactory>().Create(output)} 
                });

            var reader = new FrameReader(
                new Dictionary<Input.DirectX.Identifier, IReader>() { 
                    {input, _resolver.Resolve<IReaderFactory>().Create(input)} 
                });

            writer.Write(new Dictionary<Output.Joystick.Identifier, State> 
                { 
                    {output, new State() {Axis = new Dictionary<Axis, int> 
                        {
                            {Axis.X, 1000}
                        } } }
                });
            Thread.Sleep(1);
            Assert.AreEqual(1000, reader.Read()[input].Axis[Axis.X]);

            writer.Write(new Dictionary<Output.Joystick.Identifier, State> 
                { 
                    {output, new State() {Axis = new Dictionary<Axis, int> 
                        {
                            {Axis.X, 1001}
                        } } }
                });
            Thread.Sleep(1);
            Assert.AreEqual(1001, reader.Read()[input].Axis[Axis.X]);

            writer.Write(new Dictionary<Output.Joystick.Identifier, State> 
                { 
                    {output, new State() {Axis = new Dictionary<Axis, int> 
                        {
                            {Axis.X, 0}
                        } } }
                });
            Thread.Sleep(1);
            Assert.AreEqual(0, reader.Read()[input].Axis[Axis.X]);

            writer.Write(new Dictionary<Output.Joystick.Identifier, State> 
                { 
                    {output, new State() {Axis = new Dictionary<Axis, int> 
                        {
                            {Axis.X, -1000}
                        } } }
                });
            Thread.Sleep(1);
            Assert.AreEqual(-1000, reader.Read()[input].Axis[Axis.X]);

            writer.Write(new Dictionary<Output.Joystick.Identifier, State> 
                { 
                    {output, new State() {Axis = new Dictionary<Axis, int> 
                        {
                            {Axis.X, -1001}
                        } } }
                });
            Thread.Sleep(1);
            Assert.AreEqual(-1001, reader.Read()[input].Axis[Axis.X]);
        }
    }
}
