using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminator.Device;

namespace Terminator.Input.Device
{
    public interface IReader
    {
        State Read();
    }
}
