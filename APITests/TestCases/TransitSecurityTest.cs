using System;
using System.Collections.Generic;
using System.Net;
using PortalApp.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace PortalApp
{
    public class TransitSecurityTest : TestFixture
    {
        [TestCase(TestName = "Get all documents"), Order(0)]
        public void GetAllDocuments()
        {
            TransitSecurity transitSecurity = new TransitSecurity();

            transitSecurity.GetAllDocuments();
            var respo = transitSecurity.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            TestContext.WriteLine($"Response is {respo.response}");
        }


        [TestCase(TestName = "Get document"), Order(2)]
        public void GetDocuments()
        {
            TransitSecurity transitSecurity = new TransitSecurity();
            //string timestamp = Constants.now.AddDays(1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            string document = "Transit Security Policy and Procedure Manual - 2017.pdf";
            transitSecurity.GetDocument(document);

            var respo = transitSecurity.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
        }

        [TestCase(TestName = "Documents work flow"), Order(6)]
        public void DocumentsWorkflow()
        {
            TransitSecurity transitSecurity = new TransitSecurity();

            transitSecurity.GetAllDocuments();
            var respo = transitSecurity.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            var documents = JsonConvert.DeserializeObject<List<Document>>(respo.response);
            TestContext.WriteLine($"Response is {respo.response}");

            //documents.Count
            Random rand = new Random();
            int index = rand.Next(0, documents.Count);

            transitSecurity.GetDocument(documents[index].filename);
            respo = transitSecurity.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
        }
    }
}