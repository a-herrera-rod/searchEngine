using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine google = new Engine()
            {
                id = "Google",
                url = "https://www.googleapis.com/customsearch/v1?q={0}&cx={1}&key={2}",
                key = "AIzaSyB5jH9MO3og3hNBTLLWLtgLH8AY6mK1PXw",
                specificEngineId = "008769807058408683812:zm9ptt-wlcs"
            };
            if (args.Length > 0)
            {   
                Console.WriteLine(search(google, args[0]));
            }
            else
            {
                Console.WriteLine("Please write your search term: ");
                string searchTerm = Console.ReadLine();
                
                string googleSearchResult = search(google, searchTerm);
                JObject googleSearchObject = JObject.Parse(googleSearchResult);                
                Console.WriteLine(searchTerm + ": Google: " + googleSearchObject["searchInformation"]["totalResults"]);
            }
                
            Console.ReadLine();
        }

        public static string search(Engine engine, string value)
        {
            string result = "";
            string requestUrl = String.Format(engine.url, value, engine.specificEngineId, engine.key);
            HttpProvider http = new HttpProvider(requestUrl);
            result = http.GetResponse();

            return result;
        }
    }
}
