using System.Web.Mvc;

namespace QuanLyBanHang_63132681.Areas.Admin_63132681
{
    public class Admin_63132681AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin_63132681";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_63132681_default",
                "Admin_63132681/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}