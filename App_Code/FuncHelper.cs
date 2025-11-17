using System.Web;

namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public class FuncHelper
    {
        public static class ResourceHelper
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string GetGlobalResource(string fileName, string key)
            {
                return HttpContext.GetGlobalResourceObject(fileName, key)?.ToString() ?? string.Empty;
            }
        }
    }
}