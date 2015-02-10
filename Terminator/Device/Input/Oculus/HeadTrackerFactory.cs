using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpOVR;

namespace Terminator.Device.Input.Oculus
{
    public class HeadTrackerFactory : IHeadTrackerFactory
    {
        public IHeadTracker Create(Identifier id)
        {
            OVR.Initialize();
            var hmd = OVR.HmdCreate(id.Number);
            hmd.ConfigureTracking(TrackingCapabilities.Orientation | TrackingCapabilities.Position | TrackingCapabilities.MagYawCorrection, TrackingCapabilities.None);
            return new HeadTracker(hmd);
        }
    }
}
