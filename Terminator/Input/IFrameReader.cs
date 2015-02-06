using System.Collections.Generic;

namespace Terminator.Input
{
    public interface IFrameReader
    {
        IDictionary<Identifier, State> Read();
    }
}
