using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vJoyInterfaceWrap;

namespace Terminator.Device.Output.Joystick
{
    public class WriterFactory : IWriterFactory
    {
        public IWriter Create(Identifier id)
        {
            var device = new vJoy();
            device.AcquireVJD(id.Id);
            device.ResetVJD(id.Id);

            return new Writer(id, device);
        }
    }
}
