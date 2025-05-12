using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.Core.DTOS.BlogViewModels;
using Microsoft.AspNetCore.Http;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface IBlog
    {
        IList<ShowBlogsViewModel> GetAllBlogs();
        Blog GetBlogById(Guid id);
        Guid CreateNewBlog(Blog blog,IFormFile File);
        void UpdateBlog(Blog blog,IFormFile File);
        void DeleteBlog(Blog blog);

        #region AdminPanelIndex
        int BlogsCount();
        int VisitsCount();
        List<ShowLastBlogsViewModel> GetLastBlogs();


        #endregion


    }
}
