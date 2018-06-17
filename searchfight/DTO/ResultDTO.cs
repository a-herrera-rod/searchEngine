using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.DTO
{
    public class ResultDTO
    {
        public string SearchItem { get; set; }
        public List<int> searchResults { get; set; }
    }
}
