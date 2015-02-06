using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using Terminator.Device;

namespace Terminator.Device.Input.DirectX
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
                    Axis = new Dictionary<Axis, double>()
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

        private double TranformAxis(int directXValue)
        {
            return ((double)directXValue / 2 + 1 - 16384) / ((double)16384);
        }
    }
}
