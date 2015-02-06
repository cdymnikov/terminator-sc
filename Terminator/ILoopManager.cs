using System;

namespace Terminator
{
    public interface ILoopManager : IDisposable
    {
        void Start(Action action);
    }
}
