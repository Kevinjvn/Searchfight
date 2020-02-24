using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Searchfight.Configuration.Custom
{
    public class SearchEngineConfig : ConfigurationSection
    {

        [ConfigurationProperty("engines")]
        [ConfigurationCollection(typeof(SearchEngineCollection))]
        public SearchEngineCollection SearchEngines
        {
            get
            {
                return (SearchEngineCollection)this["engines"];
            }
        }
    }
}
