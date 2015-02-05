using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;
using SharpDX.DirectInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Terminator.Tests
{
    public class TestDeviceSection : ConfigurationSection
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}
