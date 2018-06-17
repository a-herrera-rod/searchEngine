using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using searchfight.Controller;
using searchfight.DTO;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(SearchHelper.SearchGoogle(args[0]));
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Please write your search term: ");
                    string searchTerm = Console.ReadLine();
                    string[] split = searchTerm.Split(new Char[] { ' ' });
                    ResultDTO googleResults = new ResultDTO();
                    ResultDTO bingResults = new ResultDTO();                    
                    foreach (string s in split)
                    {
                        if (s.Trim() != "")
                        {
                            string googleSearchResult = SearchHelper.SearchGoogle(s);
                            string bingSearchResult = SearchHelper.SearchBing(s);
                            JObject googleSearchObject = JObject.Parse(googleSearchResult);
                            JObject bingSearchObject = JObject.Parse(bingSearchResult);

                            Console.WriteLine(s + ": Google: " + googleSearchObject["searchInformation"]["totalResults"] + " Bing: " + bingSearchObject["webPages"]["totalEstimatedMatches"]);
                            //googleResults.SearchItem = s;
                            //googleResults.searchResults.Add(Int32.Parse(googleSearchObject["searchInformation"]["totalResults"].ToString()));
                            //bingResults.searchResults.Add(Int32.Parse(bingSearchObject["webPages"]["totalEstimatedMatches"].ToString()));
                            //Console.WriteLine();
                        }

                    }
                    
                }
            }

            Console.ReadLine();
        }


    }
}
