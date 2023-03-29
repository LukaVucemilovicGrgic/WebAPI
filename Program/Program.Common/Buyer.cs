using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Common
{
    public class Paging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class Sorting
    {
        public string OrderBy { get; set; }
        public string SortOrder { get; set; }
    }

    public class Filtering 
    {
     
    }
}
