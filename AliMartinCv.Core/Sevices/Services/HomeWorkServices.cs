using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.DTos;
using AliMartinCv.DataLayer.Entities;

namespace AliMartinCv.Core.Sevices.Services
{
    public class HomeWorkServices : IHomeWork
    {
        private readonly AliMartinCvContext _context;
        public HomeWorkServices(AliMartinCvContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHomeWork(AddHomeWorkViewModel homeWorkViewModel)
        {
            try
            {
                foreach (var homeWork in homeWorkViewModel.ClassId)
                {
                    HomeWork newHomeWork = new HomeWork()
                    {
                        ClassId = homeWork,
                        HomeWorkTitle = homeWorkViewModel.HomeWorkTitle,
                        EndTime = homeWorkViewModel.EndTime,
                        HomeWorkDescriptions = homeWorkViewModel.HomeWorkDescriptions,
                        HomeWorkType = homeWorkViewModel.HomeWorkType,
                    };
                   await _context.AddAsync(newHomeWork);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
