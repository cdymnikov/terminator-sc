using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Input.Joystick
{
    public class DeviceGuidMapFactory : IDeviceGuidMapFactory
    {
        public IDictionary<string, IList<Guid>> CreateDeviceNameToGuidMapping()
        {
            throw new Exception("!");
        }
    }
}
