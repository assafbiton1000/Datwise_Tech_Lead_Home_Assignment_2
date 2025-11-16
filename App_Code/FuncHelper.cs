using System.Web;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public class FuncHelper
    {
        public static class ResourceHelper
        {
            public static string Get(string fileName, string key)
            {
                return HttpContext.GetGlobalResourceObject(fileName, key)?.ToString() ?? string.Empty;
            }
        }
    }
}