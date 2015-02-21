using Terminator.Device;

namespace Terminator.Device.Output
{
    public interface IWriter
    {
        void Write(State state);
    }
}
