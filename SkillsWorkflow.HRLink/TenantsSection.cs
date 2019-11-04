using System;
using System.Configuration;

namespace SkillsWorkflow.HrLink
{
    public class TenantsSection : ConfigurationSection
    {
        [ConfigurationProperty("tenants", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(TenantsCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public TenantsCollection Tenants
        {
            get
            {
                TenantsCollection companiesCollection = (TenantsCollection)base["tenants"];
                return companiesCollection;
            }
        }
    }

    public class TenantsCollection : ConfigurationElementCollection
    {
        public TenantsCollection()
        {
            TenantConfigElement tenant = (TenantConfigElement)CreateNewElement();
            Add(tenant);
        }

        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.AddRemoveClearMap;

        protected override ConfigurationElement CreateNewElement()
        {
            return new TenantConfigElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((TenantConfigElement)element).Name;
        }

        public TenantConfigElement this[int index]
        {
            get
            {
                return (TenantConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        new public TenantConfigElement this[string Name] => (TenantConfigElement)BaseGet(Name);

        public int IndexOf(TenantConfigElement company)
        {
            return BaseIndexOf(company);
        }

        public void Add(TenantConfigElement company)
        {
            BaseAdd(company);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(TenantConfigElement url)
        {
            if (BaseIndexOf(url) >= 0)
                BaseRemove(url.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }

    public class TenantConfigElement : ConfigurationElement
    {
        public TenantConfigElement(String name, String apiUrl, string apiId, string apiSecret)
        {
            Name = name;
            ApiUrl = apiUrl;
            ApiId = apiId;
            ApiSecret = apiSecret;
        }

        public TenantConfigElement()
        {
        }

        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["Name"];
            }
            set
            {
                this["Name"] = value;
            }
        }

        [ConfigurationProperty("ApiUrl", IsRequired = true)]
        public string ApiUrl
        {
            get
            {
                return (string)this["ApiUrl"];
            }
            set
            {
                this["ApiUrl"] = value;
            }
        }

        [ConfigurationProperty("ApiId", IsRequired = true)]
        public string ApiId
        {
            get
            {
                return (string)this["ApiId"];
            }
            set
            {
                this["ApiId"] = value;
            }
        }

        [ConfigurationProperty("ApiSecret", IsRequired = true)]
        public string ApiSecret
        {
            get
            {
                return (string)this["ApiSecret"];
            }
            set
            {
                this["ApiSecret"] = value;
            }
        }
    }
}
