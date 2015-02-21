using System.Linq;
using System.Collections.Generic;
using Terminator.Device.Input.DirectX;
using Terminator.Device;

namespace Terminator.Device.Input
{
    public class FrameReader : IFrameReader
    {
        private readonly IDictionary<IIdentifier, IReader> _readers;

        public FrameReader(IDictionary<IIdentifier, IReader> readers)
        {
            _readers = readers;
        }

        public IDictionary<IIdentifier, State> Read()
        {
            return _readers.ToDictionary(x => x.Key, y => y.Value.Read());
        }
    }
}
