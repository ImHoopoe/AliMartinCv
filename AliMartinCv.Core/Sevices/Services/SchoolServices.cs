using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.DTos;

namespace AliMartinCv.Core.Sevices.Services
{
    public class SchoolServices : ISchool
    {
        private readonly AliMartinCvContext _context;

        public SchoolServices(AliMartinCvContext context)
        {
            _context = context;
        }

        public async Task CreateSchool(AddSchoolViewModel school)
        {
            try
            {
                School newSchool = new School()
                {
                    SchoolName = school.SchoolName
                };
                _context.Schools.Add(newSchool);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام ایجاد مدرسه مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task EditSchool(EditSchoolViewModel school)
        {
            try
            {
                School newSchool = new School()
                {
                    SchoolName = school.SchoolName,
                    SchoolId = school.SchoolId
                };
                _context.Schools.Update(newSchool);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام ویرایش مدرسه مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task DeleteSchool(int schoolId)
        {
            try
            {
                var school = await _context.Schools.FindAsync(schoolId);
                if (school != null)
                {
                    _context.Schools.Remove(school);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("مدرسه یافت نشد.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام حذف مدرسه مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task<School> GetSchoolByIdentifier(int schoolId, string searchText = null)
        {
            try
            {
                IQueryable<School> query = _context.Schools.Where(s => s.SchoolId == schoolId);

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(s => s.SchoolName.Contains(searchText));
                }

                var school = await query.FirstOrDefaultAsync();
                if (school == null)
                {
                    throw new Exception("مدرسه یافت نشد.");
                }
                return school;
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام دریافت اطلاعات مدرسه مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }

        public async Task<IEnumerable<School>> GetSchools()
        {
            try
            {
                return await _context.Schools.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("در هنگام دریافت لیست مدارس مشکلی پیش آمده است. لطفاً دوباره تلاش کنید.", ex);
            }
        }
    }
}
