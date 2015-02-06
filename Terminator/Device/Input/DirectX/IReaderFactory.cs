using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator.Device.Input.DirectX
{
    public interface IReaderFactory
    {
        IReader Create(Identifier id);
    }
}
