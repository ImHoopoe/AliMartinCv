using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.Entities
{
    public class StudentHomeWork
    {
        public int StudentHomeWorkId { get; set; }
        public int HomeWorkId { get; set; }
        public Guid StudentId { get; set; }
        public string FileName { get; set; }

        #region Relations

        public HomeWork HomeWork { get; set; }
        public Student Student { get; set; }

        #endregion
    }
}
