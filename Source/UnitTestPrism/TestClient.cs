using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Client;
using System.Threading.Tasks;

namespace UnitTestPrism
{
    [TestClass]
    public class TestClient
    {
        //public void OnGetDelivery(object sender, PrismNotify.GetDeliveryEventArgs e)
        //{
        //    /*do something with this.Deli
        //         * ......
        //         */
        //}

        //[TestMethod]
        //public void TestOAuth()
        //{
        //    ///*
        //    // * 测试
        //    // */
        //    //string host = "http://ximslkp4.apihub.cn/";
        //    //string key = "quxabf4t";
        //    //string secret = "2ipua2a6jwslp6cq6fna";

        //    //PrismDotNet prism = new PrismDotNet(host, key, secret);
        //    //prism.Notify().GetDelivery += OnGetDelivery;

        //    //PrismParams p = new PrismParams();
        //    //p["session_id"] = "aaaaaaaaaaaaaaaaaaaa";

        //    //PrismResponse rsp = prism.Client().Get("/api/platform/oauth/session_check", p);
        //    //Console.WriteLine(rsp.RequestId);
        //    //Console.WriteLine(rsp);

        //    //Debug.WriteLine(prism.OAuth().OAuthUri("http://www.baidu.com"));

        //    string host = "http://ximslkp4.apihub.cn";
        //    string key = "quxabf4t";
        //    string secret = "2ipua2a6jwslp6cq6fna";

        //    PrismClient client = new PrismClient(host, key, secret, "JK724");

        //    PrismParams p = new PrismParams();
        //    p["node_id"] = $"1087196531_1129944230";
        //    p["aftersale_id"] = "201802591615001";
        //    p["tid"] = "A20180528105039929617";

        //    PrismResponse rsp = client.Post("api/oms", p, "store.trade.aftersale.add");

        //    Console.WriteLine(rsp.RequestId);
        //    Console.WriteLine(rsp);
        //}

        [TestMethod]
        public async Task TestApi()
        {
            string host = "http://ximslkp4.apihub.cn";
            string key = "quxabf4t";
            string secret = "2ipua2a6jwslp6cq6fna";

            var client = new PrismHttpClient(host, key, secret);

            PrismParams p = new PrismParams();
            p["node_id"] = $"1087196531_1129944230";
            p["aftersale_id"] = "201802591615001";
            p["tid"] = "A20180528105039929617";

            var res = await client.Execute<object>("POST", "store.trade.aftersale.add", null, p);

            Assert.IsNotNull(res);
             
        }
    }
}
