using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism;
namespace UnitTestPrism
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PrismClient c = new PrismClient("http://192.168.51.50:8080", "pufy2a7d", "skqovukpk2nmdrljphgj");
            c.RequireOAuth("3jgbpy23wesywnemalmo");
        }
    }
}
