using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {   
                Console.WriteLine(search(args[0]));
            }
            else
            {
                Console.WriteLine("Please write your search term: ");
                string searchTerm = Console.ReadLine();
                Console.WriteLine(search(searchTerm));
            }                
                
            Console.ReadLine();
        }

        public static string search(string value)
        {
            Engine google = new Engine()
            {
                id = "Google",
                url = "https://www.googleapis.com/customsearch/v1?q={0}&cx={1}&key={2}",
                key = "AIzaSyB5jH9MO3og3hNBTLLWLtgLH8AY6mK1PXw",
                specificEngineId = "008769807058408683812:zm9ptt-wlcs"
            };

            string result = "";
            string requestUrl = String.Format(google.url, value, google.specificEngineId, google.key);
            HttpProvider http = new HttpProvider(requestUrl);
            result = http.GetResponse();

            return result;
        }
    }
}
