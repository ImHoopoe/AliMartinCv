using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.Entities
{
    public class Parent
    {
        [Key]
        public Guid ParentId { get; set; }
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid? StudentId { get; set; }
        public string StudentFullName { get; set; }
        #region Relations

        public Student Student { get; set; }
        


        #endregion
    }
}
