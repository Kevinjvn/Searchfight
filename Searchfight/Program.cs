using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Searchfight.Configuration.Custom;
using System.Net.Http;
using Searchfight.Service;
using Searchfight.Common.Exceptions;
using Searchfight.Logic;
using Searchfight.Logic.Models;

namespace Searchfight
{
    class Program
    {
        private static SearchManager searchManager = new SearchManager();

        static async Task Main(string[] args)
        {
            try
            {
                await Run(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static async Task Run(string[] args)
        {
            if(args.Length == 0)
            {
                throw new NoArgumentException("Insert at least 1 argumet to search");
            }
            else
            {
                Console.WriteLine(await searchManager.GetResults(args));
                Console.ReadLine();
            }
        }
    }
}
