using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using Terminator.Device;

namespace Terminator.Input.Device
{
    public class Reader : IReader
    {
        private readonly SharpDX.DirectInput.Joystick _joystick;

        public Reader(SharpDX.DirectInput.Joystick joystick)
        {
            _joystick = joystick;
        }

        public State Read()
        {
            _joystick.Poll();
            var state = _joystick.GetCurrentState();

            return new State()
                {
                    Axis = new Dictionary<Axis, int>()
                    {
                        {Axis.X, TranformAxis(state.X)},
                        {Axis.Y, TranformAxis(state.Y)},
                        {Axis.Z, TranformAxis(state.Z)},
                        {Axis.XRot, TranformAxis(state.RotationX)},
                        {Axis.YRot, TranformAxis(state.RotationY)},
                        {Axis.ZRot, TranformAxis(state.RotationZ)}
                    }
                };
        }

        private int TranformAxis(int directXValue)
        {
            return directXValue / 2 + 1 - 16384;
        }
    }
}
