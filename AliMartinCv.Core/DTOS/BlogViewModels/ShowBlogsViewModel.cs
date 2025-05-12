using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.Core.DTOS.BlogViewModels
{
    public class ShowBlogsViewModel
    {
        
        public Guid BlogId { get; set; }

        
        public string BlogTitle { get; set; }

        public string BlogShortDescription { get; set; }


        public string BlogThumbnail { get; set; }

        public DateTime BlogPublishDate { get; set; }

        public int Visit { get; set; }

        public bool BlogIsDeleted { get; set; }

        public string BlogGroupTitle { get; set; }
        public string? BlogSubGroupTitle { get; set; }

    }
}
