using System.Web;
using System.Web.Mvc;

namespace Saibalini_test_sitecore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
