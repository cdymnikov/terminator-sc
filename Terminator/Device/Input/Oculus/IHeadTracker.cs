using SharpOVR;

namespace Terminator.Device.Input.Oculus
{
    public interface IHeadTracker
    {
        PoseF ReadLeftEye();

        PoseF ReadRightEye();
    }
}
