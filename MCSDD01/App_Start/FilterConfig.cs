using System.Web;
using System.Web.Mvc;

namespace MCSDD01
{
    public class FilterConfig  /*若是全域性過濾器就直接寫這邊*/
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                View ="Error 2"
            });
        }
    }
}
