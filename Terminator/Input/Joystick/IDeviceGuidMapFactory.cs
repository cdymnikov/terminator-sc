using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator.Input.Joystick
{
    interface IDeviceGuidMapFactory
    {
        IDictionary<string, IList<Guid>> CreateDeviceNameToGuidMapping();
    }
}
