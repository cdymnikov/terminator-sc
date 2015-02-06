using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;
using Terminator.Input.DirectX;

namespace Terminator.Input
{
    public class Configuration : ConfigurationSection
    {
        [ConfigurationProperty("joysticks", IsRequired = true)]
        public Joysticks Joysticks
        {
            get
            {
                return (Joysticks)this["joysticks"];
            }
            set
            {
                this["joysticks"] = value;
            }
        }
    }

    [ConfigurationCollection(typeof(JoystickIdentifier),
    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class Joysticks : ConfigurationElementCollection
    {
        #region Constructors
        static Joysticks()
        {
            m_properties = new ConfigurationPropertyCollection();
        }

        public Joysticks()
        {
        }
        #endregion

        #region Fields
        private static ConfigurationPropertyCollection m_properties;
        #endregion

        #region Properties
        protected override ConfigurationPropertyCollection Properties
        {
            get { return m_properties; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
        #endregion

        #region Indexers
        public JoystickIdentifier this[int index]
        {
            get { return (JoystickIdentifier)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }

        public Identifier this[string name]
        {
            get 
            {
                var configId = (JoystickIdentifier)base.BaseGet(name);
                return new Identifier(configId.ProductName, configId.ProductNumber); 
            }
        }
        #endregion

        #region Overrides
        protected override ConfigurationElement CreateNewElement()
        {
            return new JoystickIdentifier();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as JoystickIdentifier).Name;
        }
        #endregion
    }

    public class JoystickIdentifier : ConfigurationSection
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

        [ConfigurationProperty("productName", IsRequired = true)]
        public string ProductName
        {
            get
            {
                return (string)this["productName"];
            }
            set
            {
                this["productName"] = value;
            }
        }

        [ConfigurationProperty("productNumber", IsRequired = true)]
        public int ProductNumber
        {
            get
            {
                return (int)this["productNumber"];
            }
            set
            {
                this["productNumber"] = value;
            }
        }
    }
}
