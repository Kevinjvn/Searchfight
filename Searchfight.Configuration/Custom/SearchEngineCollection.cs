using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Searchfight.Configuration.Custom
{
    public class SearchEngineCollection : ConfigurationElementCollection
    {
        public SearchEngineElement this[int index]
        {
            get
            {
                return (SearchEngineElement)BaseGet(index);
            }

            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        public new SearchEngineElement this[string key]
        {
            get
            {
                return (SearchEngineElement)BaseGet(key);
            }

            set
            {
                if (BaseGet(key) != null)
                    BaseRemoveAt(BaseIndexOf(BaseGet(key)));

                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SearchEngineElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SearchEngineElement)element).Name;
        }
    }
}
