using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.Core.Tools;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace AliMartinCv.Core.Sevices.Services
{

    public class BlogGroupServices : IBlogGroup
    {
        private readonly AliMartinCvContext _context;
        public BlogGroupServices(AliMartinCvContext context)
        {
            _context = context;
        }







        #region Index

        public Guid CreateNewBlogGroup(BlogGroup blogGroup)
        {
            blogGroup.BlogGroupId = Tools.Tools.UniqNameMaker();
            _context.Add(blogGroup);
            _context.SaveChanges();
            return blogGroup.BlogGroupId;
        }

        public void DeleteBlogGroup(BlogGroup blogGroup)
        {
            var blogSubGroups = _context.BlogGroups.Where(b => b.BlogGroupParentId == blogGroup.BlogGroupId).ToList();
            foreach (var blogSubGroup in blogSubGroups)
            {
                blogSubGroup.IsDeleted = true;
            }
            blogGroup.IsDeleted = true;
            UpdateBlogGroup(blogGroup);
        }

        public IList<SelectListItem> GetAllMainGroups()
        {
            return _context.BlogGroups.Where(g => g.BlogGroupParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.BlogGroupTitle,
                    Value = g.BlogGroupId.ToString()
                })
                .ToList();
        }

        public List<SelectListItem> GetAllSubGroups(Guid id)
        {
            return _context.BlogGroups.Where(g => g.BlogGroupParentId == id).Select(sg => new SelectListItem()
            {
                Value = sg.BlogGroupId.ToString(),
                Text = sg.BlogGroupTitle.ToString()

            }).ToList();
        }

        public BlogGroup GetBlogGroupById(Guid id)
        {
            return _context.BlogGroups.Find(id);
        }

        public List<BlogGroup> GetBlogGroups()
        {
            return _context.BlogGroups.ToList();
        }

        public string GetGroupTitleById(Guid id)
        {
            return _context.BlogGroups.Find(id).BlogGroupTitle;
        }

        public IList<SelectListItem> GetSubGroups(Guid id)
        {
           return _context.BlogGroups.Where(g=> g.BlogGroupParentId== id)
               .Select(sg=>new SelectListItem()
               {
                   Text = sg.BlogGroupTitle,
                   Value = sg.BlogGroupId.ToString()
               }).ToList();
        }

        public int GroupsCount()
        {
           return GetAllMainGroups().Count();
        }

        public int SubGroupCounts()
        {
            return _context.BlogGroups.Where(g => g.BlogGroupParentId != null).ToList().Count();
        }

        public void UpdateBlogGroup(BlogGroup blogGroup)
        {
            _context.Update(blogGroup);
            _context.SaveChanges();
        }


        #endregion
    }
}
