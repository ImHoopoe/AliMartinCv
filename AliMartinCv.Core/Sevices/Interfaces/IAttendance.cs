using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.DataLayer.DTos;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface IAttendance
    {
        Task<bool> CreateAttendance(CreateAttendanceViewModel attendances);
        Task<List<AttendanceRecord>> ShowClassAttendace(int classId);
        void ReCheckAll();
    }
}
