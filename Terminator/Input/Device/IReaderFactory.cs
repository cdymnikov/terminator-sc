﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator.Input.Device
{
    public interface IReaderFactory
    {
        IReader Create(Identifier id);
    }
}