using System.Linq;
using System.Collections.Generic;
using Terminator.Device;
using vJoyInterfaceWrap;

namespace Terminator.Device.Output.Joystick
{
    public class Writer : IWriter
    {
        private readonly Identifier _id;
        private readonly vJoy _device;
        private readonly IDictionary<Axis, HID_USAGES> _axisToVjoy = new Dictionary<Axis, HID_USAGES>()
            {
                {Axis.X, HID_USAGES.HID_USAGE_X},
                {Axis.Y, HID_USAGES.HID_USAGE_Y},
                {Axis.Z, HID_USAGES.HID_USAGE_Z},
                {Axis.XRot, HID_USAGES.HID_USAGE_RX},
                {Axis.YRot, HID_USAGES.HID_USAGE_RY},
                {Axis.ZRot, HID_USAGES.HID_USAGE_RZ},
            };

        public Writer(Identifier id, vJoy device)
        {
            _id = id;
            _device = device;
        }

        public void Write(State state)
        {
            state.Axis.ToList().ForEach(x => 
                {
                    _device.SetAxis(Transform(x.Value), _id.Id, _axisToVjoy[x.Key]);
                });
        }

        private int Transform(int value)
        {
            return value + 16384;
        }
    }
}
