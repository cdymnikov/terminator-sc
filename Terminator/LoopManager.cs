using System;
using System.Threading;
using System.Threading.Tasks;

namespace Terminator
{
    public class LoopManager : ILoopManager
    {
        private bool _keepRunning = false;

        private Task _task;

        public void Start(Action action)
        {
            _keepRunning = true;
            _task = Task.Run(() => Loop(action));
        }

        public void Loop(Action action)
        {
            while (_keepRunning)
            {
                action();
            }
        } 

        public void Dispose()
        {
            _keepRunning = false;
            _task.Wait();
        }
    }
}
