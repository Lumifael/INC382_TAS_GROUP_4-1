using System.Web;
using System.Web.Mvc;

namespace TAS_Dashboard_G4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
