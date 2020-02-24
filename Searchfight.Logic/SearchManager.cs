using Searchfight.Configuration;
using Searchfight.Logic.Models;
using Searchfight.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Searchfight.Common.Extensions;
using Searchfight.Configuration.Models;

namespace Searchfight.Logic
{
    public class SearchManager
    {
        private HtmlScrapperService htmlScrapperService = new HtmlScrapperService();

        public async Task<string> GetResults(string[] searchKeywords)
        {
            List<SearchResult> searchResults = new List<SearchResult>();
            Dictionary<string, string> queryParams = null;
            string scrappedHtml = null;

            SearchResult searchResult = null;
            foreach (var keyword in searchKeywords)
            {
                foreach (var searchEngine in ConfigurationManager.SearchEngines)
                {
                    queryParams = BuildQueryParams(searchEngine, keyword);
                    scrappedHtml = await htmlScrapperService.Scrap(searchEngine.Address, queryParams);

                    searchResult = new SearchResult
                    {
                        SearchEngineName = searchEngine.Name,
                        ResultCount = GetResultCount(scrappedHtml, searchEngine),
                        Keyword = keyword
                    };
                    searchResults.Add(searchResult);
                }
            }

            string formattedResults = GetFormmatedResults(searchResults);
            string winners = GetWinners(searchResults);
            string totalWinner = GetTotalWinner(searchResults);

            return $"{formattedResults}\n\n{winners}\n\n{totalWinner}";
        }

        private Dictionary<string, string> BuildQueryParams(SearchEngine searchEngine, string searchKeyword)
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add(searchEngine.QueryParam, searchKeyword);
            return queryParams;
        }

        private string GetFormmatedResults(List<SearchResult> results)
        {
            return results.GroupBy(res => res.Keyword, res => res, (query, res) =>
            {
                return new
                {
                    Query = query,
                    Results = res.Select(r => $"\t{r.SearchEngineName}: {r.ResultCount}\n").Aggregate(string.Empty, (r1, r2) => r1 + r2)
                };
            }).Select(r => $"{r.Query}:\n{r.Results}").Aggregate(string.Empty, (r1, r2) => r1 + r2);
        }

        private long GetResultCount(string html, SearchEngine searchEngine)
        {
            var first = html.Match(searchEngine.TagRegex);
            var second = first.Match(searchEngine.ValueRegex);
            var replace = second.Replace(".", ",");
            return long.Parse(replace, System.Globalization.NumberStyles.AllowThousands);
        }

        private string GetWinners(List<SearchResult> results)
        {
            return results.GroupBy(res => res.SearchEngineName, res => res, (engine, res) =>
            {
                return new
                {
                    EngineName = engine,
                    WinnerQuery = res.OrderByDescending(_res => _res.ResultCount).First().Keyword
                };
            }).Select(r => $"{r.EngineName} winner: {r.WinnerQuery}\n").Aggregate(string.Empty, (r1, r2) => r1 + r2);
        }

        private string GetTotalWinner(List<SearchResult> results)
        {
            string totalWinner = results.GroupBy(res => res.Keyword, res => res, (key, res) =>
            {
                return new
                {
                    Query = key,
                    TotalResults = res.Sum(r => r.ResultCount)
                };
            }).OrderByDescending(r => r.TotalResults).First().Query;
            return $"Total winner: {totalWinner}";
        }
    }
}
