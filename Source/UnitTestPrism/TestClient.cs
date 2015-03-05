using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism;
namespace UnitTestPrism
{
    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void TestOAuth()
        {
            PrismClient c = new PrismClient("http://192.168.51.50:8080", "pufy2a7d", "skqovukpk2nmdrljphgj");
            PrismResponse response = c.RequireOAuth("3jgbpy23wesywnemalmo");
            Debug.WriteLine(response);
        }
    }
}
