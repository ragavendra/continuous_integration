using System;
using NUnit.Framework;

namespace AppName
{
    public class TestFixture
    {

        [SetUp]
        public void BeforeTest()
        {
            TestContext.WriteLine("Test start time {0}", DateTime.Now);
        }

        [TearDown]
        public void AfterTest()
        {
            TestContext.WriteLine("Test en(d) time {0}", DateTime.Now);
        }

    }

}