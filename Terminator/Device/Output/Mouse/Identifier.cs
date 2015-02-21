using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Device.Output.Mouse
{
    public class Identifier
    {
        public Identifier(uint id)
        {
            Id = id;
        }

        public uint Id { get; private set; }

        public override bool Equals(Object obj)
        {
            Identifier other = obj as Identifier;
            if (other == null)
                return false;
            else
                return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); 
        }
    }
}
