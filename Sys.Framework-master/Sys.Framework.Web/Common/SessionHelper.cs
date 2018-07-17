using System.Web;

namespace Sys.Framework.Web.Common
{
    public class SessionHelper
    {
        public static object Get(string name)
        {
            return HttpContext.Current.Session[name.ToLower()];
        }

        public static void Add(string name, object val)
        {
            HttpContext.Current.Session.Remove(name.ToLower());
            HttpContext.Current.Session.Add(name.ToLower(), val);
        }
        public static void Add(string name, object val, int Minutes)
        {
            HttpContext.Current.Session.Remove(name.ToLower());
            HttpContext.Current.Session.Add(name.ToLower(), val);
            HttpContext.Current.Session.Timeout = Minutes;
        }
        public static void Remove(string name)
        {
            HttpContext.Current.Session[name.ToLower()] = null;
            HttpContext.Current.Session.Remove(name.ToLower());
        }
        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
