using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Newtonsoft.Json;
using NUnit.Framework;
using PortalApp.Models;

namespace PortalApp
{
    public class FeedbackTest : TestFixture
    {


        [TestCase(TestName = "Feedback workflow"), Order(0)]
        public void FeedbackWorkflow()
        {

            Feedback feedBack = new Feedback();
            Models.Feedback feedBack_ = new Models.Feedback();
            feedBack_.userId = "test@TransLink.ca";
            feedBack_.userEmail = "test@TransLink.ca";
            feedBack_.userDisplayName = "DisplayName";
            feedBack_.empId = "EMPID";
            feedBack_.feedbackDate = DateTime.Now;
                //.ToString("yyyy-MM-dd");
            feedBack_.featureId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            feedBack_.comment = "Test comment " + feedBack_.feedbackDate.ToString("O");
            feedBack.CreateFeedback(feedBack_);

            var respo = feedBack.Post();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            var feedBack_1 = JsonConvert.DeserializeObject<Models.Feedback>(respo.response);
            Assert.IsNotNull(feedBack_1.feedbackId, "Feedback id is null");

            feedBack_.feedbackId = feedBack_1.feedbackId;

            //check data
            assertFeedback(feedBack_, feedBack_1);

            //all feedback
            feedBack.GetFeedback();
            respo = feedBack.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            var feedBackList = JsonConvert.DeserializeObject<Models.FeedbackList>(respo.response);

            foreach (var feed in feedBackList.list)
            {
                if (feed.feedbackId.Equals(feedBack_1.feedbackId))
                {
                    assertFeedback(feedBack_, feed);
                    break;
                }
                else
                    continue;
            }

            //by feedback id
            feedBack.GetFeedback(feedBack_1.feedbackId);
            respo = feedBack.Get();
            Assert.AreEqual(200, (int)respo.status, "Status code is not 200");
            feedBack_1 = JsonConvert.DeserializeObject<Models.Feedback>(respo.response);

            assertFeedback(feedBack_, feedBack_1);

            //by feedback date
            feedBack.GetFeedback("", getDateTimeRFC3339(feedBack_.feedbackDate.AddDays(-1)), getDateTimeRFC3339(feedBack_1.feedbackDate.AddDays(1)));
            respo = feedBack.Get();
            Assert.AreEqual(200, (int)respo.status, "Status code is not 200");
            feedBackList = JsonConvert.DeserializeObject<Models.FeedbackList>(respo.response);

            foreach (var feed in feedBackList.list)
                if (!feed.feedbackId.Equals(feedBack_1.feedbackId))
                {
                    continue;
                }
                else
                {
                    feedBack_1 = feed;
                    break;
                }

            assertFeedback(feedBack_, feedBack_1);

            //by feedback id del
            feedBack.DeleteFeedback(feedBack_1.feedbackId);
            respo = feedBack.Delete();
            Assert.AreEqual(200, (int)respo.status, "Status code is not 200");

            //by feedback id
            feedBack.GetFeedback(feedBack_1.feedbackId);
            respo = feedBack.Get();
            Assert.AreEqual(500, (int)respo.status, "Status code is not 500");

        }

        public void assertFeedback(Models.Feedback feedBack_, Models.Feedback feedBack_1)
        {

            Assert.AreEqual(feedBack_.feedbackId, feedBack_1.feedbackId, "Feedback id does not match");
            Assert.AreEqual(feedBack_.userId, feedBack_1.userId, "User id does not match");
            Assert.AreEqual(feedBack_.userEmail, feedBack_1.userEmail, "User email does not match");
            Assert.AreEqual(feedBack_.featureId, feedBack_1.featureId, "Feature id does not match");
            Assert.AreEqual(feedBack_.comment, feedBack_1.comment, "User comment does not match");

        }

        public string getDateTimeRFC3339(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }


    }
}
