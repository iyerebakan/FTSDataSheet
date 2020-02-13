using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.ConstantLists
{
    public class Months
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Months> MonthList = new List<Months>();

        static Months()
        {
            MonthList.Add(new Months { Id = 1, Name = "Ocak" });
            MonthList.Add(new Months { Id = 2, Name = "Şubat" });
            MonthList.Add(new Months { Id = 3, Name = "Mart" });
            MonthList.Add(new Months { Id = 4, Name = "Nisan" });
            MonthList.Add(new Months { Id = 5, Name = "Mayıs" });
            MonthList.Add(new Months { Id = 6, Name = "Haziran" });
            MonthList.Add(new Months { Id = 7, Name = "Temmuz" });
            MonthList.Add(new Months { Id = 8, Name = "Ağustos" });
            MonthList.Add(new Months { Id = 9, Name = "Eylül" });
            MonthList.Add(new Months { Id = 10, Name = "Ekim" });
            MonthList.Add(new Months { Id = 11, Name = "Kasım" });
            MonthList.Add(new Months { Id = 12, Name = "Aralık" });
        }

        public static string GetMonthName(int Id)
        {
            var month = MonthList.Find(k => k.Id == Id);
            if (month == null)
                return "";

            return month.Name;
        }
    }
}
