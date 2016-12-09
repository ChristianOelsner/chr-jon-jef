using System.Web;
using System.Web.Mvc;

namespace JJC_Music_Store_v_1_3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
