using System.Collections.Generic;
using Terminator.Device;

namespace Terminator.Input
{
    public interface IFrameReader
    {
        IDictionary<Identifier, State> Read();
    }
}
