using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.DTos;
using Microsoft.EntityFrameworkCore;

namespace AliMartinCv.Core.Sevices.Services
{
    public class ClassService : IClass
    {
        private readonly AliMartinCvContext _context;

        public ClassService(AliMartinCvContext context)
        {
            _context = context;
        }

        public async Task CreateClass(CreateClassViewModel createClass)
        {
            try
            {
                Class newClass = new Class()
                {
                    SchoolId = createClass.SchoolId,
                    ClassName = createClass.ClassName
                };
                _context.Classes.Add(newClass);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام ایجاد کلاس مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task EditClass(Class updatedClass)
        {
            try
            {
                _context.Classes.Update(updatedClass);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام ویرایش کلاس مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task DeleteClass(int classId)
        {
            try
            {
                var classToDelete = await _context.Classes.FindAsync(classId);
                if (classToDelete != null)
                {
                    _context.Classes.Remove(classToDelete);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("کلاس مورد نظر یافت نشد.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام حذف کلاس مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task<Class> GetClassById(int classId)
        {
            try
            {
                return await _context.Classes
                                     .Include(c => c.School)
                                     .Include(c => c.Students)
                                     .FirstOrDefaultAsync(c => c.ClassId == classId);
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام دریافت اطلاعات کلاس مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            try
            {
                return await _context.Classes
                                     .Include(c => c.School)
                                     .Include(c => c.Students)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام دریافت لیست کلاس‌ها مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }
    }
}
