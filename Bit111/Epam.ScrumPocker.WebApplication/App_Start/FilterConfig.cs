using System.Web;
using System.Web.Mvc;

namespace Epam.ScrumPocker.WebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
