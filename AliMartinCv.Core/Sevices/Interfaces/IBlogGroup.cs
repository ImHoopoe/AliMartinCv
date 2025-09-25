using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface IBlogGroup
    {
        string GetGroupTitleById(Guid id);
        Guid CreateNewBlogGroup(BlogGroup blogGroup);
        List<BlogGroup> GetBlogGroups();
        BlogGroup GetBlogGroupById(Guid id);
        void UpdateBlogGroup(BlogGroup blogGroup);
        void DeleteBlogGroup(BlogGroup blogGroup);
        List<SelectListItem> GetAllSubGroups(Guid id);
        Task<IList<SelectListItem>> GetAllMainGroups();
        Task<IList<SelectListItem>> GetSubGroups(Guid id);

        #region AdminIndex

        Task<int> GroupsCount();
        Task<int> SubGroupCounts();


        #endregion

    }
}
