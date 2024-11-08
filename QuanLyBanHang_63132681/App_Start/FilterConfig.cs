using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang_63132681
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
