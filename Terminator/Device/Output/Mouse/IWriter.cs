using Terminator.Device;

namespace Terminator.Device.Output.Mouse
{
    public interface IWriter
    {
        void Write(State state);
    }
}
