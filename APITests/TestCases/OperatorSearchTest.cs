using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using PortalApp.Models;

namespace PortalApp
{
    public class OperatorSearchTest : TestFixture
    {

        [TestCase(TestName = "Operator search workflow"), Order(0)]
        public void OperatorSearch()
        {

            OperatorSearch opSrch = new OperatorSearch();
            opSrch.Search("*");
            //opSrch.GetDetails(employeeId);

            var respo = opSrch.Get();

            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            var operators = JsonConvert.DeserializeObject<List<OperatorSearch_>>(respo.response);

            //foreach (var operator_ in operators)
            Random rand = new Random();

            //check 6 times if search is working
            for (int i = 0; i < 6; i++)
            {
                int randNo = rand.Next(0, operators.Count - 1);
                opSrch.GetDetails(operators[randNo].employeeId);
                respo = opSrch.Get();
                Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
                var operator1 = JsonConvert.DeserializeObject<OperatorSearch_>(respo.response);
                Assert.AreEqual(operators[randNo].employeeId, operator1.employeeId, $"Employee id don't match, Expected - {operators[randNo].employeeId} , Actual - {operator1.employeeId}");
            }
        }

    }
}
