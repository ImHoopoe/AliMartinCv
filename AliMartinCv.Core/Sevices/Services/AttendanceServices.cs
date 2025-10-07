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
using Microsoft.EntityFrameworkCore;

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

        public Task<List<AttendanceRecord>> ShowClassAttendance(int classId)
        {
            return _context.Students.Where(s => s.ClassId == classId)
                .SelectMany(a => a.Attendances)
                .OrderBy(a => a.Date).Include(a=> a.Student).Select(a => new AttendanceRecord()
                {
                    Date = a.Date,
                    IsPresent = a.IsPresent,
                    Remarks = a.Remarks,
                    StudentId = a.StudentId,
                    Type = a.Type,
                    Name = a.Student.Name,
                    LastName = a.Student.LastName
                    
                }).ToListAsync();
        }

        public async void ReCheckAll()
        {
          var att =  _context.Attendances.Where(a => a.Type == AttendanceType.Late).ToList();
          foreach (var VARIABLE in att)
          {
              VARIABLE.Type = AttendanceType.Present;
              _context.Update(VARIABLE);
          }

          _context.SaveChanges();

        }

        public async Task<List<AttendanceRecord>> ShowStudentAttendance(Guid studentId)
        {
            return await _context.Attendances
                .Where(a => a.StudentId == studentId)
                .Select(a=> new AttendanceRecord()
                {
                    Date = a.Date,
                    IsPresent = a.IsPresent,
                    Name = a.Student.Name,
                    LastName = a.Student.LastName,
                    Remarks = a.Remarks,
                    StudentId = a.StudentId,
                    Type = a.Type
                })
                .ToListAsync();
        }

        public async Task<int> GetStudentAttendancesCounts(Guid studentId)
        {
            return await _context.Attendances
                .Where(a => a.StudentId == studentId && !a.IsPresent)
                .CountAsync();
        }
    }
}
