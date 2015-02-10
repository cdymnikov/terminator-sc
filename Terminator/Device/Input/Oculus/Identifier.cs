using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Device.Input.Oculus
{
    public class Identifier
    {
        public Identifier(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }

        public override bool Equals(Object obj)
        {
            Identifier other = obj as Identifier;
            if (other == null)
                return false;
            else
                return Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
