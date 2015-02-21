using System;
using System.Linq;
using System.Collections.Generic;
using Terminator.Device.Output.Joystick;
using Terminator.Device;

namespace Terminator.Device.Output
{
    public class FrameWriter : IFrameWriter
    {
        private readonly IDictionary<IIdentifier, IWriter> _writers;

        public FrameWriter(IDictionary<IIdentifier, IWriter> writers)
        {
            _writers = writers;
        }

        public void Write(IDictionary<IIdentifier, State> frame)
        {
            frame.ToList().ForEach(x => 
                {
                    _writers[x.Key].Write(x.Value);
                });
        }
    }
}
