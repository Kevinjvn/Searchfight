using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Searchfight.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns matched sub string based on regex
        /// </summary>
        /// <param name="text">string reference</param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static string Match(this string text, string regex)
        {
            return Regex.Match(text, regex, RegexOptions.Singleline)?.Value;
        }
    }
}
