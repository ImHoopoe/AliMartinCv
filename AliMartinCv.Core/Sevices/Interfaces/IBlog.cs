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
        Task<List<ShowBlogsViewModel>> GetAllBlogs();
        Task<Blog> GetBlogById(Guid id);
        Task<bool> CreateNewBlog(Blog blog,IFormFile File);
        Task<bool> UpdateBlog(Blog blog,IFormFile File);
        Task<bool> DeleteBlog(Blog blog);

        #region AdminPanelIndex
        Task<int> BlogsCount();
        Task<int> VisitsCount();
        Task<List<ShowBlogsViewModel>> GetLastBlogs(int take = 3);


        #endregion


    }
}
