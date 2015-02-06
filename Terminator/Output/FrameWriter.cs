using System;
using System.Linq;
using System.Collections.Generic;
using Terminator.Output.Joystick;
using Terminator.Device;

namespace Terminator.Output
{
    public class FrameWriter : IFrameWriter
    {
        private readonly IDictionary<Identifier, IWriter> _writers;

        public FrameWriter(IDictionary<Identifier, IWriter> writers)
        {
            _writers = writers;
        }

        public void Write(IDictionary<Identifier, State> frame)
        {
            frame.ToList().ForEach(x => 
                {
                    _writers[x.Key].Write(x.Value);
                });
        }
    }
}
