using System.ComponentModel.DataAnnotations;

namespace ConfigurationWebApiService.Helpers
{
    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
          : base(typeof(DateTime), DateTime.Now.AddYears(-20).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString()) { }
    }
}
