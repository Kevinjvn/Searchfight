using Searchfight.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Logic.Models
{
    public class SearchResult
    {
        public string SearchEngineName { get; set; }
        public long ResultCount { get; set; }
        public string Keyword { get; set; }
    }
}
