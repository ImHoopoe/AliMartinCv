using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.Entities
{
   public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ClassId { get; set; }

        #region Relations
        public Class Class { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        #endregion


    }
}
