using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.DTos;

namespace AliMartinCv.Core.Sevices.Services
{
    public class StudentServices : IStudent
    {
        private readonly AliMartinCvContext _context;

        public StudentServices(AliMartinCvContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(CreateStudentViewModel newStudent)
        {
            try
            {
                Student student = new Student()
                {
                    Name = newStudent.Name,
                    LastName = newStudent.LastName,
                    StudentId = newStudent.StudentId,
                    ClassId = newStudent.ClassId
                };
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام ایجاد دانش‌آموز مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task EditStudent(Student updatedStudent)
        {
            try
            {
                _context.Students.Update(updatedStudent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام ویرایش دانش‌آموز مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task DeleteStudent(Guid studentId)
        {
            try
            {
                var student = await _context.Students.FindAsync(studentId);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("دانش‌آموز یافت نشد.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام حذف دانش‌آموز مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task<Student> GetStudentById(Guid studentId, string searchText = null)
        {
            try
            {
                IQueryable<Student> query = _context.Students
                                                    .Include(s => s.Class)
                                                    .Where(s => s.StudentId == studentId);

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(s => s.Name.Contains(searchText)||s.LastName.Contains(searchText));
                }

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام دریافت اطلاعات دانش‌آموز مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents(int? id)
        {
            try
            {
                if (id!=null)
                {
                    return await _context.Students.Where(s=> s.ClassId==id)
                        .Include(s => s.Class)
                        .ToListAsync();
                }
                return await _context.Students
                                     .Include(s => s.Class)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام دریافت لیست دانش‌آموزان مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task<bool> IsStudentExists(string UserName)
        {
           return await _context.Students.AnyAsync(s => s.UserName == UserName);
        }

        public async Task<Student> GetStudentByUserName(string UserName)
        {
            return await _context.Students.SingleOrDefaultAsync(s => s.UserName == UserName);
        }

        public async Task<int> GetStudentsCounts(Guid? studentId,Guid? parentId)
        {
            if (studentId!=null)
            {
                return await _context.Students.Where(s => s.StudentId == studentId).CountAsync();
            }

            if (parentId!=null)
            {
                return await _context.Students.Where(s => s.ParentId == parentId).CountAsync();
            }
            return await _context.Students.CountAsync();
        }
    }
}
