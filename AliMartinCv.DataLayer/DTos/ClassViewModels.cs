using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.DTos
{
    public class CreateClassViewModel
    {
        [Required(ErrorMessage = "This Is Required")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "This Is Required")]
        public int SchoolId { get; set; }
        
    }
    public class ShowClassStudentsViewModel
    {

        [Required(ErrorMessage = "This Is Required")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "This Is Required")]
        public int SchoolId { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public int ClassId { get; set; }

        
    }

}
