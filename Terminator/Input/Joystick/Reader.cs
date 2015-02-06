using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Input.Joystick
{
    public class Reader : IReader
    {
        private readonly SharpDX.DirectInput.Joystick _joystick;

        public Reader(SharpDX.DirectInput.Joystick joystick)
        {
            _joystick = joystick;
        }

        public int ReadXAxis()
        {
            _joystick.Poll();
            var state = _joystick.GetCurrentState();
            return state.X / 2 + 1 - 16384;
        }
    }
}
