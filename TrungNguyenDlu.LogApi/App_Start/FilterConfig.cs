using System.Web;
using System.Web.Mvc;

namespace TrungNguyenDlu.LogApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
