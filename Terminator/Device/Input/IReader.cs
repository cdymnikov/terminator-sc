using Terminator.Device;

namespace Terminator.Device.Input
{
    public interface IReader
    {
        State Read();
    }
}