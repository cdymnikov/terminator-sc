using System.Linq;
using System.Collections.Generic;
using Terminator.Device;
using vJoyInterfaceWrap;
using System.Runtime.InteropServices;

namespace Terminator.Device.Output.Mouse
{
    public class Writer : IWriter
    {

        public Writer()
        {

        }

        public void Write(State state)
        {
            var wheel = 0;

            var input = new MouseKeyIO.INPUT[1];
            input[0].type = MouseKeyIO.INPUT_MOUSE;
            input[0].mi = MouseInput((int)state.Axis[Axis.X], (int)state.Axis[Axis.Y], (uint)wheel, 0, MouseKeyIO.MOUSEEVENTF_MOVE | MouseKeyIO.MOUSEEVENTF_WHEEL);

            MouseKeyIO.SendInput(1, input, Marshal.SizeOf(input[0].GetType()));
        }

        static private MouseKeyIO.MOUSEINPUT MouseInput(int x, int y, uint data, uint t, uint flag)
        {
            var mi = new MouseKeyIO.MOUSEINPUT { dx = x, dy = y, mouseData = data, time = t, dwFlags = flag };
            return mi;
        }
    }
}
