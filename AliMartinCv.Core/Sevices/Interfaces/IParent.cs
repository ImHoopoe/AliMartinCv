using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.DataLayer.Entities;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface IParent
    {
        Task<bool> IsExistsParent(string UserName);
        Task<Parent> GetParentByUserName(string UserName);
       
    }
}
