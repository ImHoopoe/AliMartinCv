using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.Core.DTOS.BlogViewModels
{
    public class ShowLastBlogsViewModel
    {
        public Guid BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogShortDesciption { get; set; }
        public string BlogImage { get; set; }
        public int Visits { get; set; }

    }
}
