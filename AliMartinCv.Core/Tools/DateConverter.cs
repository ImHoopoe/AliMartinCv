using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliMartinCv.Core.Tools
{
   public static class DateConverter
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);
            return $"{year}/{month:D2}/{day:D2}";
        }
        public static int GetShamsiYear(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            return year;
        }
    }

}
