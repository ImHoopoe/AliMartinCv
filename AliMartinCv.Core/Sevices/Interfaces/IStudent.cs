using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.DataLayer.DTos;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface IStudent
    {
        Task CreateStudent(CreateStudentViewModel newStudent);
        Task EditStudent(Student updatedStudent);
        Task DeleteStudent(Guid studentId);
        Task<Student> GetStudentById(Guid studentId, string searchText = null);
        Task<IEnumerable<Student>> GetAllStudents(int? id);
    }
}
