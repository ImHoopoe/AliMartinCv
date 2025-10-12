using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.DataLayer.DTos;

namespace AliMartinCv.Core.Sevices.Interfaces
{
    public interface IHomeWork
    {
        Task<bool> AddHomeWork(AddHomeWorkViewModel homeWorkViewModel);
    }
}
