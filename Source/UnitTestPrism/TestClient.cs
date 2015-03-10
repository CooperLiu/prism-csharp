using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism;
using System.Net;
using Prism.Notify;

namespace UnitTestPrism
{
    [TestClass]
    public class TestClient
    {
        public void OnGetDelivery(object sender, PrismNotify.GetDeliveryEventArgs e)
        {
            /*do something with this.Deli
                 * ......
                 */
        }

        [TestMethod]
        public void TestOAuth()
        {
            /*
             * 测试
             */
            string host = "http://192.168.51.50:8080";
            string key = "pufy2a7d";
            string secret = "skqovukpk2nmdrljphgj";

            PrismDotNet p = new PrismDotNet(host, key, secret);
            p.Notify().GetDelivery += OnGetDelivery;

            Debug.WriteLine(p.OAuth().OAuthUri("http://www.baidu.com"));
        }
    }
}
