using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism;
using System.Net;

namespace UnitTestPrism
{
    [TestClass]
    public class TestClient
    {
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
            Debug.WriteLine(p.OAuth.RequireOAuth("dvyb25s76jlhrojg6hfy"));
        }
    }
}
