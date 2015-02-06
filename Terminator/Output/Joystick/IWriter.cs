using Terminator.Device;

namespace Terminator.Output.Joystick
{
    public interface IWriter
    {
        void Write(State state);
    }
}
