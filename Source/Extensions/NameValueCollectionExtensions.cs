using System.Collections.Specialized;
using System.Linq;

namespace Prism.Extensions
{
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// 将有序字典转换为字符连接串（a=1 & b=2 & c=3）
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="isUrlEncode"></param>
        /// <param name="isStringValue"></param>
        /// <returns></returns>
        public static string ToQueryString(this NameValueCollection nc, bool isUrlEncode = false, bool isStringValue = false)
        {
            var str =
                nc.AllKeys.Where(k => !string.IsNullOrEmpty(nc[k]?.ToString()))
                    .Select(k => isUrlEncode ? $"{k}={nc[k].ToString().UrlEncode()}" : (isStringValue ? $"{k}=\"{nc[k]}\"" : $"{k}={nc[k]}"))
                    .Aggregate((a, b) => a + "&" + b);
            return str;
        }
    }
}
