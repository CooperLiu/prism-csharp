using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism;
using System.Net;
using Prism.Client;
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

            PrismDotNet prism = new PrismDotNet(host, key, secret);
            prism.Notify().GetDelivery += OnGetDelivery;

            PrismParams p = new PrismParams();
            p["e"] = "va";
            p["c"] = "va";
            p["b"] = "vb";
            p["0"] = "v0";

            PrismResponse rsp = prism.Client().Get("platform/notify/status", p);
            Console.WriteLine(rsp.RequestId);
            Console.WriteLine(rsp);

            Debug.WriteLine(prism.OAuth().OAuthUri("http://www.baidu.com"));
        }
    }
}
