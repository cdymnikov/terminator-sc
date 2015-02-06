using Terminator.Device;

namespace Terminator.Device.Output.Joystick
{
    public interface IWriter
    {
        void Write(State state);
    }
}
