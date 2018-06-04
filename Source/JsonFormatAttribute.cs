using System;

namespace Prism
{
    /// <summary>
    /// 使用Json格式化
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class JsonFormatAttribute : Attribute
    {
        public JsonFormatAttribute()
        {
        }

    }
}
