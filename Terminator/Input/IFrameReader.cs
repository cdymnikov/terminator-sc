using System.Collections.Generic;
using Terminator.Device;
using Terminator.Input.DirectX;

namespace Terminator.Input
{
    public interface IFrameReader
    {
        IDictionary<Identifier, State> Read();
    }
}
