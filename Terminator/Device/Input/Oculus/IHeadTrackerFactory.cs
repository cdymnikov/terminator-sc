namespace Terminator.Device.Input.Oculus
{
    public interface IHeadTrackerFactory
    {
        IHeadTracker Create(Identifier id);
    }
}
