using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public Guid StudentId { get; set; }
        public string? Remarks { get; set; }
        public AttendanceType Type { get; set; }

        #region Realtions
        public Student Student { get; set; }
        #endregion
    }

    public enum AttendanceType
    {
        Present,     
        Absent,      
        Leave,       
        Late         
    }

}
