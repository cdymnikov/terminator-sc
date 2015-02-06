using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Input.DirectX
{
    public class ReaderFactory : IReaderFactory
    {
        private readonly DirectInput _directInput;

        private readonly IDeviceNameResolver _resolver;

        public ReaderFactory(DirectInput directInput, IDeviceNameResolver resolver)
        {
            _directInput = directInput;
            _resolver = resolver;
        }

        public IReader Create(Identifier id)
        {
            var joystick = new SharpDX.DirectInput.Joystick(_directInput, _resolver.Resolve(id));
            joystick.Properties.BufferSize = 128;
            joystick.Acquire();

            return new Reader(joystick);
        }
    }
}
