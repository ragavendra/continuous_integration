using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using PortalApp.Models;

namespace PortalApp
{
    public class AuthorizationTest : TestFixture
    {


        [TestCase(TestName = "Get features for Access roles"), TestCaseSource(typeof(Data), "AccessRoles"), Order(0)]
        public void GetFeatures(string accessRole, object[] access)
        {

            Authorization auth = new Authorization();

            auth.GetAuthorizationFeatures(accessRole);

            var respo = auth.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var features = JsonConvert.DeserializeObject<List<Features>>(respo.response);

            TestContext.WriteLine($"Roles for {accessRole}");

            foreach (var feature in features)
            {
                //Assert.That(feature.displayOrder, Is.TypeOf(typeof(int)));
                //Assert.That(feature.id, Is.TypeOf(typeof(string)));
                //Assert.That(feature.name, Is.TypeOf(typeof(string)));
                //Assert.That(feature.displayName, Is.TypeOf(typeof(string)));
                //Assert.That(feature.description, Is.TypeOf(typeof(string)));
                //Assert.That(feature.url, Is.TypeOf(typeof(string)));
                //Assert.That(feature.parentFeatureId, Is.TypeOf(typeof(string)));
                ////Assert.AreNotEqual(memberId, member.identification, $"Member id - {memberId} exists in the system");
                //TestContext.WriteLine(feature.name);
                //Assert.That(feature.name, Is.TypeOf(typeof(string)));

                Assert.Contains(feature.name, access, $"Access role {feature.name} not expected");

            }

            Assert.AreEqual(access.Length, features.Count, $"Features count don't match, Expected - {access.Length} , Actual - {features.Count}");

        }

        [TestCase(TestName = "Get Access roles"), Order(2)]
        public void GetAccessRoles()
        {

            Authorization auth = new Authorization();

            auth.AccessRoles();

            var respo = auth.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var roles = JsonConvert.DeserializeObject<List<AccessRoles>>(respo.response);

            foreach (var role in roles)
            {
                Assert.That(role.roleName, Is.TypeOf(typeof(string)));
                Assert.That(role.displayName, Is.TypeOf(typeof(string)));
                Assert.That(role.description, Is.TypeOf(typeof(string)));
                //Assert.AreNotEqual(memberId, member.identification, $"Member id - {memberId} exists in the system");

                TestContext.WriteLine(role.roleName);
                Assert.Contains(role.roleName, Data.AccessRoles_, $"Access role {role.roleName} not in list");
            }

            Assert.AreEqual(Data.AccessRoles_.Length, roles.Count, $"Roles count is not valid - ${roles.Count}");
        }

    }
}
