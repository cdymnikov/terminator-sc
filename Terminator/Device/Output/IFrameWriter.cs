using System.Collections.Generic;
using Terminator.Device;
using Terminator.Device.Output.Joystick;

namespace Terminator.Device.Output
{
    public interface IFrameWriter
    {
        void Write(IDictionary<IIdentifier, State> frame);
    }
}
