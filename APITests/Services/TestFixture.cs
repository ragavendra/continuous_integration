using System;
using NUnit.Framework;

namespace PortalApp
{
    public class TestFixture
    {

        public DateTime startTime;

        [SetUp]
        public void BeforeTest()
        {
            //startTime = DateTime.Now;
            //TestContext.WriteLine("Test start time {0}", startTime.ToString("s"));
        }

        [TearDown]
        public void AfterTest()
        {
            //TestContext.WriteLine("Test duration {0} s", (DateTime.Now - startTime).TotalSeconds);
            //TestContext.WriteLine("Test en(d) time {0}", DateTime.Now.ToString("s"));
        }

    }

}