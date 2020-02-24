using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Configuration.Models
{
    public class SearchEngine
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string QueryParam { get; set; }
        public string TagRegex { get; set; }
        public string ValueRegex { get; set; }
    }
}
