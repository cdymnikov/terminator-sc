using System.Collections.Generic;
using Terminator.Device;
using Terminator.Output.Joystick;

namespace Terminator.Output
{
    public interface IFrameWriter
    {
        void Write(IDictionary<Identifier, State> frame);
    }
}
