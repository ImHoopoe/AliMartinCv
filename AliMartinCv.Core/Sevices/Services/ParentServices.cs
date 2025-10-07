using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AliMartinCv.Core.Sevices.Services
{
    public class ParentServices : IParent
    {
        private readonly AliMartinCvContext _context;
        public ParentServices(AliMartinCvContext context)
        {
            _context = context;
        }

        public async Task<Parent> GetParentByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(userName));
            }

            return await _context.Parents
                .SingleOrDefaultAsync(p => p.UserName == userName);
        }


        public async Task<bool> IsExistsParent(string UserName)
        {
            return await _context.Parents.AnyAsync(p => p.UserName == UserName);
        }
    }
}
