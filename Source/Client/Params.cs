using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Prism.Client
{
    public class PrismParams : NameValueCollection
    {

        public override string ToString()
        {
            List<string> items = new List<string>();

            foreach (String name in this)
                items.Add(String.Concat(PrismParams.Encode(name)
                    , "=", PrismParams.Encode(this[name])));

            return String.Join("&", items.ToArray());
        }

        public byte[] ToBytes()
        {
            string str = this.ToString();
            return Encoding.ASCII.GetBytes(str);
        }

        public String headers_str()
        {
            List<string> items = new List<string>();

            SortedDictionary<string, string> sort = new SortedDictionary<string, string>();
            foreach (var k in this.AllKeys)
            {
                if (k == "Authorization" || k.StartsWith("X-Api-"))
                {
                    sort.Add(k, this.Get(k));
                }
            }

            foreach (var k in sort.Keys)
            {
                items.Add(String.Concat(k, "=", sort[k]));
            }
            return String.Join("&", items.ToArray());
        }

        public String sort_join(String skip)
        {
            List<string> items = new List<string>();

            SortedDictionary<string, string> sort = new SortedDictionary<string, string>();
            foreach (var k in this.AllKeys)
            {
                if (k != skip)
                {
                    sort.Add(k, this.Get(k));
                }
            }

            foreach (var k in sort.Keys)
            {
                items.Add(String.Concat(k, "=", sort[k]));
            }
            return String.Join("&", items.ToArray());
        }

        static public string Encode(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) {
                return s;
            }
            s = HttpUtility.UrlEncode(s, System.Text.Encoding.ASCII);
            s = s.Replace("!", "%21");
            s = s.Replace("*", "%2A");
            s = s.Replace("+", "%20");
            s = s.Replace("(", "%28");
            s = s.Replace(")", "%29");
            char[] temp = s.ToCharArray();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == '%')
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                    temp[i + 2] = char.ToUpper(temp[i + 2]);
                }
            }
            return new string(temp);
        }
    }
}