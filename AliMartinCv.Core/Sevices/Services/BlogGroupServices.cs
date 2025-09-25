
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.Core.Tools;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliMartinCv.Core.Services.Services
{
    public class BlogGroupServices : IBlogGroup
    {
        private readonly AliMartinCvContext _context;

        public BlogGroupServices(AliMartinCvContext context)
        {
            _context = context;
        }

        public Guid CreateNewBlogGroup(BlogGroup blogGroup)
        {
            blogGroup.BlogGroupId = Tools.Tools.UniqNameMaker();
            _context.BlogGroups.Add(blogGroup);
            _context.SaveChanges();
            return blogGroup.BlogGroupId;
        }

        public void DeleteBlogGroup(BlogGroup blogGroup)
        {
            // Soft-delete all children
            var subGroups = _context.BlogGroups
                .Where(g => g.BlogGroupParentId == blogGroup.BlogGroupId)
                .ToList();

            foreach (var sg in subGroups)
            {
                sg.IsDeleted = true;
            }

            blogGroup.IsDeleted = true;
            UpdateBlogGroup(blogGroup);
        }

        public async Task<IList<SelectListItem>> GetAllMainGroups()
        {
            return await _context.BlogGroups
                .Where(g => g.BlogGroupParentId == null && !g.IsDeleted)
                .Select(g => new SelectListItem
                {
                    Value = g.BlogGroupId.ToString(),
                    Text = g.BlogGroupTitle
                })
                .ToListAsync();
        }

        public async Task<IList<SelectListItem>> GetSubGroups(Guid id)
        {
            return await _context.BlogGroups
                .Where(g => g.BlogGroupParentId == id && !g.IsDeleted)
                .Select(g => new SelectListItem
                {
                    Value = g.BlogGroupId.ToString(),
                    Text = g.BlogGroupTitle
                })
                .ToListAsync();
        }

        public List<SelectListItem> GetAllSubGroups(Guid id)
        {
            // Legacy sync method, but you might consider deprecating this
            return _context.BlogGroups
                .Where(g => g.BlogGroupParentId == id && !g.IsDeleted)
                .Select(g => new SelectListItem
                {
                    Value = g.BlogGroupId.ToString(),
                    Text = g.BlogGroupTitle
                })
                .ToList();
        }

        public BlogGroup GetBlogGroupById(Guid id)
        {
            return _context.BlogGroups.Find(id);
        }

        public List<BlogGroup> GetBlogGroups()
        {
            return _context.BlogGroups.AsNoTracking().ToList();
        }

        public string GetGroupTitleById(Guid id)
        {
            var grp = _context.BlogGroups
                .AsNoTracking()
                .FirstOrDefault(g => g.BlogGroupId == id);
            return grp?.BlogGroupTitle;
        }

        public async Task<int> GroupsCount()
        {
            return await _context.BlogGroups
                .CountAsync(g => g.BlogGroupParentId == null && !g.IsDeleted);
        }

        public async Task<int> SubGroupCounts()
        {
            return await _context.BlogGroups
                .CountAsync(g => g.BlogGroupParentId != null && !g.IsDeleted);
        }

        public void UpdateBlogGroup(BlogGroup blogGroup)
        {
            _context.BlogGroups.Update(blogGroup);
            _context.SaveChanges();
        }
    }
}
