using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminator.Device.Output.Mouse
{
    public class WriterFactory : IWriterFactory
    {
        public IWriter Create(Identifier id)
        {
            return new Writer();
        }
    }
}
