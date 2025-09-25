using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.Entities
{
    public class Class
    {
        [Key]
        public int ClassId{ get; set; }
        public string ClassName { get; set; }
        public int SchoolId { get; set; }
        #region Relations
        public School School { get; set; }
        public IEnumerable<Student> Students { get; set; }

        #endregion
    }
}
