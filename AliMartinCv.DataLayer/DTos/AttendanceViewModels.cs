using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.DataLayer.DTos
{
    public class AttendanceRecord
    {
        public Guid StudentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public AttendanceType Type { get; set; }
        public string? Remarks { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }

    public class CreateAttendanceViewModel
    {
        public IEnumerable<AttendanceRecord> AttendanceRecords { get; set; }
        public IEnumerable<Student>? Students { get; set; }
    }

}
