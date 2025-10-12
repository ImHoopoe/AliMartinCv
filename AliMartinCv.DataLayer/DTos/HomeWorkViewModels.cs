using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.DTos
{
    public class AddHomeWorkViewModel
    {
        public int HomeWorkId { get; set; }
        public ICollection<int> ClassId { get; set; }
        public string HomeWorkTitle { get; set; }
        public string? HomeWorkDescriptions { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public HomeWorkType HomeWorkType { get; set; }
        
    }
}
