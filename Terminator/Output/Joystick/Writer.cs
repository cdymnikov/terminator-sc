using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;

namespace Terminator.Output.Joystick
{
    public class Writer : IWriter
    {
        private readonly Identifier _id;
        private readonly vJoy _device;

        public Writer(Identifier id, vJoy device)
        {
            _id = id;
            _device = device;
        }

        public void WriteXAxis(int value)
        {
            _device.SetAxis(value, _id.Id, HID_USAGES.HID_USAGE_X);
        }
    }
}
