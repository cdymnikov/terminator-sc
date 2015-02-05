using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator.Output.Joystick
{
    public interface IWriter
    {
        void WriteXAxis(int value);
    }
}
