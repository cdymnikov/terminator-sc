using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Terminator.Device;
using Terminator.Device.Output;
using Terminator.Device.Output.Mouse;
using System.Threading;
using System.Windows.Forms;

namespace Terminator.Device
{
    [TestClass]
    public class When_writing_mouse_delta
    {
        private readonly Resolver _resolver = new Resolver();

        [TestMethod]
        public void Cursor_position_changes_correctly()
        {
            var writer = _resolver.Resolve<IWriterFactory>().Create(new Identifier(0));

            writer.Write(new State{
                    Axis = new Dictionary<Axis, double>(){
                        {Axis.X, -9999},
                        {Axis.Y, -9999}
                    }
                });
            Assert.AreEqual(Cursor.Position.X, 0);
            Assert.AreEqual(Cursor.Position.Y, 0);

            Thread.Sleep(1);

            writer.Write(new State
            {
                Axis = new Dictionary<Axis, double>(){
                        {Axis.X, 10},
                        {Axis.Y, 20}
                    }
            });
            Assert.AreEqual(Cursor.Position.X, 10);
            Assert.AreEqual(Cursor.Position.Y, 20);
        }
    }
}
