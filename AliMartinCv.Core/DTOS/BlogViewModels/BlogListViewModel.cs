using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.Core.DTOS.BlogViewModels
{
    public class BlogListViewModel
    {
        public List<ShowBlogsViewModel> Blogs { get; set; }
        public string SearchQuery { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 6; 
    }
}
