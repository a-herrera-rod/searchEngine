using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.Controller
{
    class SearchHelper
    {

        public static string SearchGoogle(string value)
        {
            EngineDTO engine = new EngineDTO()
            {    
                Id = "Google",
                Url = "https://www.googleapis.com/customsearch/v1?q={0}&cx={1}&key={2}",
                Key = "AIzaSyA2Isp3M6aO4MNStWfW3x3F-1xsOtsTdf4",
                SpecificEngineId = "008769807058408683812:zm9ptt-wlcs"
            };
            string result = "";
            string requestUrl = String.Format(engine.Url, value, engine.SpecificEngineId, engine.Key);
            HttpProvider http = new HttpProvider(requestUrl);
            result = http.GetResponse();

            return result;
        }
        public static string SearchBing(string value)
        {
            EngineDTO engine = new EngineDTO()
            {
                Id = "Bing",
                Url = "https://api.cognitive.microsoft.com/bing/v7.0/search?q={0}",
                Key = "3fa160597390418ab23c7ca9a5c8d311"
            };
            string result = "";
            string requestUrl = String.Format(engine.Url, value);
            HttpProvider http = new HttpProvider(requestUrl, engine.Key);
            result = http.GetResponse();

            return result;
        }
    }
}
