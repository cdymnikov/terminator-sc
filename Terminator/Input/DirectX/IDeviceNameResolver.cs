using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator.Input.DirectX
{
    public interface IDeviceNameResolver
    {
        Guid Resolve(Identifier id);
    }
}
