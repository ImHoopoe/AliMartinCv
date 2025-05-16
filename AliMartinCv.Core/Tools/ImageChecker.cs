using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.Core.Security
{
    public static class ImageChecker
    {
        public static bool IsImage(this Stream stream)
        {
            try
            {
                using var img = System.Drawing.Image.FromStream(stream);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
