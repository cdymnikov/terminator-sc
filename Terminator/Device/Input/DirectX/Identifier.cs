using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace Terminator.Device.Input.DirectX
{
    public class Identifier : IIdentifier
    {
        public Identifier(string productName, int number)
        {
            ProductName = productName;
            Number = number;
        }

        public string ProductName { get; private set; }

        public int Number { get; private set; }

        public override bool Equals(Object obj)
        {
            Identifier other = obj as Identifier;
            if (other == null)
                return false;
            else
                return ProductName.Equals(other.ProductName) && Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            return ProductName.GetHashCode() * Number.GetHashCode();
        }
    }
}
