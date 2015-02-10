using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;
using SharpOVR;
using Terminator.Device;

namespace Terminator.Device.Input.Oculus
{
    public class Reader : IReader
    {
        private readonly IHeadTracker _tracker;

        public Reader(IHeadTracker tracker)
        {
            _tracker = tracker;
        }

        public State Read()
        {
            var left = _tracker.ReadLeftEye();
            var right = _tracker.ReadRightEye();

            return new State()
            {
                Axis = new Dictionary<Axis, double>()
                    {
                        {Axis.X, Average(left.Position.X, right.Position.X)},
                        {Axis.Y, Average(left.Position.Y, right.Position.Y)},
                        {Axis.Z, Average(left.Position.Z, right.Position.Z)},
                        {Axis.XRot, right.Orientation.X},
                        {Axis.YRot, right.Orientation.Y},
                        {Axis.ZRot, right.Orientation.Z}
                    }
            };
        }

        private double Average(float a, float b)
        {
            return (a+b)/2;
        }
    }
}
