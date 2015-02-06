
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Device.Output.Joystick
{
    public class Identifier
    {
        public Identifier(uint id)
        {
            Id = id;
        }

        public uint Id { get; private set; }
    }
}
