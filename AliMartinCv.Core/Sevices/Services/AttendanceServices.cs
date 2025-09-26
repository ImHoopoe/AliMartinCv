using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.DTos;
using AliMartinCv.DataLayer.Entities;

namespace AliMartinCv.Core.Sevices.Services
{
    public class AttendanceServices : IAttendance
    {
        private readonly AliMartinCvContext _context;
        public AttendanceServices(AliMartinCvContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAttendance(CreateAttendanceViewModel model)
        {
            try
            {
                var dt = DateTime.Now;;
                var attendanceRecords = model.AttendanceRecords.Select(record => new Attendance
                {
                    StudentId = record.StudentId,
                    Date = dt,
                    IsPresent = record.IsPresent,
                    Type = record.Type,
                    Remarks = record.Remarks
                }).ToList();

               
                await _context.Attendances.AddRangeAsync(attendanceRecords);

                
                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception e)
            {
               
                Console.WriteLine($"Error: {e.Message}");
                return false; 
            }
        }

    }
}
