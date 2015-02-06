using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Input.DirectX
{
    public class Identifier
    {
        public Identifier(string productName, int number)
        {
            ProductName = productName;
            Number = number;
        }

        public string ProductName { get; private set; }

        public int Number { get; private set; }
    }
}
