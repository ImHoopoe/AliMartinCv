using AliMartinCv.DataLayer.DTos;
using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface ISchool
    {
        Task CreateSchool(AddSchoolViewModel school);
        Task EditSchool(EditSchoolViewModel school);
        Task DeleteSchool(int schoolId);
        Task<School> GetSchoolByIdentifier(int schoolId, string searchText = null);
        Task<IEnumerable<School>> GetSchools();

    }
}
