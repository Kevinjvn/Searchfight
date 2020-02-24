using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Searchfight.Configuration.Custom
{
    public class SearchEngineElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired =false)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }

            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("address", IsKey = true, IsRequired = true)]
        public string Address
        {
            get
            {
                return (string)base["address"];
            }

            set
            {
                base["address"] = value;
            }
        }

        [ConfigurationProperty("queryParam", IsKey = true, IsRequired = true)]
        public string QueryParam
        {
            get
            {
                return (string)base["queryParam"];
            }

            set
            {
                base["queryParam"] = value;
            }
        }

        [ConfigurationProperty("tagRegex", IsKey = true, IsRequired = true)]
        public string TagRegex
        {
            get
            {
                return (string)base["tagRegex"];
            }

            set
            {
                base["tagRegex"] = value;
            }
        }

        [ConfigurationProperty("valueRegex", IsKey = true, IsRequired = true)]
        public string ValueRegex
        {
            get
            {
                return (string)base["valueRegex"];
            }

            set
            {
                base["valueRegex"] = value;
            }
        }
    }
}
