using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.DTos
{
    public class AddSchoolViewModel
    {
        [Required(ErrorMessage = "This Is Required ")]
        public string SchoolName { get; set; }




    } 
    public class EditSchoolViewModel
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }




    }
    public class IndexSchoolViewModel
    {
        public IEnumerable<School> Schools { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        




    }

}
