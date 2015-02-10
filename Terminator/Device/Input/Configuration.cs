using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;
using Terminator.Device.Input.DirectX;
using Terminator.Device.Input.Oculus;

namespace Terminator.Device.Input
{
    public class Configuration : ConfigurationSection
    {
        [ConfigurationProperty("joysticks", IsRequired = false)]
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

        [ConfigurationProperty("oculi", IsRequired = false)]
        public Oculi Oculi
        {
            get
            {
                return (Oculi)this["oculi"];
            }
            set
            {
                this["oculi"] = value;
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

        public new DirectX.Identifier this[string name]
        {
            get 
            {
                var configId = (JoystickIdentifier)base.BaseGet(name);
                return new DirectX.Identifier(configId.ProductName, configId.ProductNumber); 
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

    [ConfigurationCollection(typeof(OculusIdentifier),
CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class Oculi : ConfigurationElementCollection
    {
        #region Constructors
        static Oculi()
        {
            m_properties = new ConfigurationPropertyCollection();
        }

        public Oculi()
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
        public OculusIdentifier this[int index]
        {
            get { return (OculusIdentifier)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }

        public new Oculus.Identifier this[string name]
        {
            get
            {
                var configId = (OculusIdentifier)base.BaseGet(name);
                return new Oculus.Identifier(configId.Number);
            }
        }
        #endregion

        #region Overrides
        protected override ConfigurationElement CreateNewElement()
        {
            return new OculusIdentifier();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as OculusIdentifier).Name;
        }
        #endregion
    }

    public class OculusIdentifier : ConfigurationSection
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

        [ConfigurationProperty("number", IsRequired = true)]
        public int Number
        {
            get
            {
                return (int)this["number"];
            }
            set
            {
                this["number"] = value;
            }
        }
    }
}
