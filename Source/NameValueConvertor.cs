using System;
using System.Linq;
using Newtonsoft.Json;
using Prism.Client;

namespace Prism
{
    public static class NameValueConvertor
    {
        public static PrismParams Convert<TRequest>(TRequest request, string timeFormat = "yyyy-MM-dd HH:mm:ss", JsonSerializerSettings settings = null)
        {
            var type = typeof(TRequest);

            var properties = type.GetProperties();

            var nv = new PrismParams();

            foreach (var p in properties)
            {
                var jsonAttribute = p.GetCustomAttributes(typeof(JsonFormatAttribute), false).FirstOrDefault();

                var pt = p.PropertyType;

                object value = p.GetValue(request);

                if (pt == typeof(DateTime?))
                {
                    if (value != null)
                    {
                        value = ((DateTime)value).ToString(timeFormat);
                    }
                }

                if (jsonAttribute != null || pt.IsClass)
                {
                    value = $"{JsonConvert.SerializeObject(value)}";
                }


                nv.Add(p.Name, value?.ToString() ?? null);
            }

            return nv;
        }


    }
}
