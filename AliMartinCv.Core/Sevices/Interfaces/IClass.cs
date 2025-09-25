using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.DataLayer.DTos;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface IClass
    {
        Task CreateClass(CreateClassViewModel newClass);
        Task EditClass(Class updatedClass);
        Task DeleteClass(int classId);
        Task<Class> GetClassById(int classId);
        Task<IEnumerable<Class>> GetAllClasses();
    }
}
