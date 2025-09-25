using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.DTos
{
    public class CreateStudentViewModel
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ClassId { get; set; }

        
    }
}
