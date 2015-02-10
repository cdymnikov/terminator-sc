using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpOVR;

namespace Terminator.Device.Input.Oculus
{
    public class ReaderFactory : IReaderFactory
    {
        private readonly IHeadTrackerFactory _trackerFactory;

        public ReaderFactory(IHeadTrackerFactory trackerFactory)
        {
            _trackerFactory = trackerFactory;
        }

        public IReader Create(Identifier id)
        {
            return new Reader(_trackerFactory.Create(id));
        }
    }
}
