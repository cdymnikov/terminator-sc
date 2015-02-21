using System.Collections.Generic;
using Terminator.Device;
using Terminator.Device.Input.DirectX;

namespace Terminator.Device.Input
{
    public interface IFrameReader
    {
        IDictionary<IIdentifier, State> Read();
    }
}
