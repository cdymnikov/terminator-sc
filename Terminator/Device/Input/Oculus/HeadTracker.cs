using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;
using SharpOVR;
using Terminator.Device;

namespace Terminator.Device.Input.Oculus
{
    public class HeadTracker : IHeadTracker
    {
        private readonly HMD _hmd;

        public HeadTracker(HMD hmd)
        {
            _hmd = hmd;
        }

        public PoseF ReadLeftEye(){
            return _hmd.GetHmdPosePerEye(EyeType.Left);
        }

        public PoseF ReadRightEye(){
            return _hmd.GetHmdPosePerEye(EyeType.Right);
        }
    }
}
