using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Newtonsoft.Json;
using Prism.Client;
using Prism.Extensions;

namespace Prism
{
    public static class NameValueConvertor
    {
        public static PrismParams MapFrom<TRequest>(TRequest request, string timeFormat = "yyyy-MM-dd HH:mm:ss", JsonSerializerSettings settings = null)
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

                if (jsonAttribute != null || pt.Namespace.StartsWith("Prism"))
                {
                    value = $"{JsonConvert.SerializeObject(value)}";
                }


                nv.Add(p.Name, value?.ToString() ?? "");
            }

            return nv;
        }

        public static TRequest MapTo<TRequest>(NameValueCollection requestData, string timeFormat = "yyyy-MM-dd HH:mm:ss", JsonSerializerSettings settings = null)
        {
            var type = typeof(TRequest);
            var obj = Activator.CreateInstance(type);

            var properties = type.GetProperties();

            foreach (var p in properties)
            {
                var jsonAttribute = p.GetCustomAttributes(typeof(JsonFormatAttribute), false).FirstOrDefault();

                var name = p.Name;

                var value = requestData[name]?.UrlDecode();

                var pt = p.PropertyType;

                if (!string.IsNullOrEmpty(value))
                {

                    if (pt == typeof(DateTime?))
                    {
                        var v = Convert.ToInt32(value).GetDateTimeFromUnixTimeStamp(); //DateTime.ParseExact(value, timeFormat, null);
                        p.SetValue(obj, v);
                    }
                    else if (jsonAttribute != null)
                    {
                        var attr = (JsonFormatAttribute)jsonAttribute;

                        if (attr.Type == pt.GetGenericArguments()[0])
                        {
                            var list = JsonConvert.DeserializeObject(value, pt);
                            p.SetValue(obj, list);
                        }

                    }
                    else
                    {
                        var setValue = System.Convert.ChangeType(value, pt);

                        p.SetValue(obj, setValue);
                    }


                }

            }

            return (TRequest)obj;
        }
    }
}
