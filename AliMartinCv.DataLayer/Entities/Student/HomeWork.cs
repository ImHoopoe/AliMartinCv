using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.Entities
{
    public class HomeWork
    {
        public int HomeWorkId { get; set; }
        public int ClassId { get; set; }
        public string HomeWorkTitle { get; set; }
        public string? HomeWorkDescriptions { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public HomeWorkType HomeWorkType { get; set; }
        #region Relations

        public Class Class { get; set; }
        public ICollection<StudentHomeWork> StudentHomeWorks { get; set; } 


        #endregion
    }

    public enum HomeWorkType
    {
        [Display(Name = "تکلیف روزانه")]
        DailyHomework,
        [Display(Name = "جریمه")]
        Punishment,
        [Display(Name = "کاربرگ")]
        Worksheet,
        [Display(Name = "آدینه")]
        Adineh
        
    }

}
