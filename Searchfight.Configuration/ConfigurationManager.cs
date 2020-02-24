using Searchfight.Configuration.Custom;
using Searchfight.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Configuration
{
    public static class ConfigurationManager
    {
        public static readonly List<SearchEngine> SearchEngines = new List<SearchEngine>();
        static ConfigurationManager()
        {
            SearchEngineConfig searchEngineConfig = (SearchEngineConfig)System.Configuration.ConfigurationManager.GetSection("searchEngine");

            foreach (SearchEngineElement instance in searchEngineConfig.SearchEngines)
            {
                SearchEngines.Add(new SearchEngine
                {
                    Name = instance.Name,
                    Address = instance.Address,
                    QueryParam = instance.QueryParam,
                    TagRegex = instance.TagRegex,
                    ValueRegex = instance.ValueRegex
                });
            }
        }
    }
}
