using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator.Device.Output.Joystick
{
    public interface IWriterFactory
    {
        IWriter Create(Identifier id);
    }
}
