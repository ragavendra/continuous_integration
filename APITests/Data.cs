
using System;

namespace PortalApp
{
    public class Data
    {

        static object[] AccessRoles = 
        {
            new object[] {"TL_Developer", new object[] {
                "JobAid-IncidentReport-Approve", "JobAid-IncidentReport-Assign", "JobAid-IncidentReport-Reject", "JobAid-IncidentReport-View", "JobAid-IncidentReport-ViewAll", "Alerts",
                "ATC-MIMIC", "Bus-Locator", "Cancellations", "Rosters-ChangeSettings", "CIR-List", "COR-List", "JobAid-IncidentReport-LandingPage", "Events", "Fares",
                "FirstLast-Train", "Google-Maps", "Google-Transit", "Google-Translate", "Guideway-Maps", "Handbook", "Headways", "Interlines", "JobAid-IncidentReport-Create",
                "JobAid-IncidentReport-Edit", "Rosters-ManageRosters", "NextBus", "Operator-Search", "Policies-Procedures", "Paddles", "Rider-Info", "Route-Maps", "Rulebook",
                "Security-Roster", "Station-View", "Trolley-Overhead", "Rosters-View", "PortalApp-Admin", "EOT-Realtime", "EOT-Timelapse", "Feedback", "Feedback-Manage", "Feedback-Submit",
                "Policies-Procedures-TSEC-Manual" }},
            new object[] {"TL_QA", new object[] {
                "JobAid-IncidentReport-Approve", "JobAid-IncidentReport-Assign", "JobAid-IncidentReport-Reject", "JobAid-IncidentReport-View", "JobAid-IncidentReport-ViewAll", "Alerts",
                "ATC-MIMIC", "Bus-Locator", "Cancellations", "Rosters-ChangeSettings", "CIR-List", "COR-List", "JobAid-IncidentReport-LandingPage", "Events", "Fares",
                "FirstLast-Train", "Google-Maps", "Google-Transit", "Google-Translate", "Guideway-Maps", "Handbook", "Headways", "Interlines", "JobAid-IncidentReport-Create",
                "JobAid-IncidentReport-Edit", "Rosters-ManageRosters", "NextBus", "Operator-Search", "Policies-Procedures", "Paddles", "Rider-Info", "Route-Maps", "Rulebook",
                "Security-Roster", "Station-View", "Trolley-Overhead", "Rosters-View", "PortalApp-Admin", "EOT-Realtime", "EOT-Timelapse", "Feedback", "Feedback-Manage", "Feedback-Submit",
                "Policies-Procedures-TSEC-Manual" }},
            new object[] {"TSUP_Supervisor", new object[] {
                "Bus-Locator", "CIR-List", "COR-List", "Cancellations", "Paddles", "Headways", "Route-Maps", "Trolley-Overhead", "Operator-Search", "Events", "Interlines",
                "Policies-Procedures", "Feedback", "Feedback-Manage", "Feedback-Submit" }},
            new object[] {"STA_DutyManager", new object[] {
                "JobAid-IncidentReport-LandingPage", "JobAid-IncidentReport-Assign", "JobAid-IncidentReport-Reject", "JobAid-IncidentReport-View", "JobAid-IncidentReport-ViewAll",
                "Feedback", "Feedback-Manage", "Feedback-Submit" }},
            new object[] {"STA_Supervisor", new object[] {
                "JobAid-IncidentReport-LandingPage", "JobAid-IncidentReport-Approve", "JobAid-IncidentReport-Edit", "JobAid-IncidentReport-Reject", "JobAid-IncidentReport-View",
                "JobAid-IncidentReport-Create", "Rulebook", "Feedback", "Feedback-Manage", "Feedback-Submit" }},
            new object[] {"STA_Attendant", new object[] {
                "JobAid-IncidentReport-Create", "JobAid-IncidentReport-Edit", "JobAid-IncidentReport-View", "JobAid-IncidentReport-LandingPage", "ATC-MIMIC", "Station-View",
                "NextBus", "FirstLast-Train", "Alerts", "Handbook", "Guideway-Maps", "Fares", "Rulebook", "Google-Transit", "Rider-Info" } },
            new object[] {"TSO_Cooridinator", new object[] {
                "Bus-Locator", "NextBus", "CIR-List", "Route-Maps", "Fares", "Operator-Search", "Rider-Info", "Google-Maps", "Security-Roster", "Alerts", "Google-Translate",
                "Policies-Procedures", "Policies-Procedures-TSEC-Manual", "Rosters-ManageRosters", "Rosters-View", "Feedback-Submit" }},
            new object[] {"TSO_Officer", new object[] {"Bus-Locator", "NextBus", "CIR-List", "Route-Maps", "Fares", "Operator-Search", "Rider-Info", "Google-Maps", "Security-Roster", "Alerts",
                "Google-Translate", "Policies-Procedures", "Policies-Procedures-TSEC-Manual", "Rosters-View", "Feedback-Submit" }},
            new object[] {"TSO_TCOMM", new object[] {"Bus-Locator", "NextBus", "CIR-List", "Route-Maps", "Fares", "Operator-Search", "Rider-Info", "Google-Maps", "Security-Roster", "Alerts",
                "Google-Translate", "Policies-Procedures", "Policies-Procedures-TSEC-Manual", "Rosters-View", "Feedback-Submit" }},
            new object[] {"TSO_SuperAdmin", new object[] {
                "Bus-Locator", "NextBus", "CIR-List", "Route-Maps", "Fares", "Operator-Search", "Rider-Info", "Google-Maps", "Security-Roster", "Alerts", "Google-Translate",
                "Policies-Procedures", "Policies-Procedures-TSEC-Manual", "Rosters-ManageRosters", "Rosters-View", "Rosters-ChangeSettings", "Feedback-Submit" }},
            new object[] {"EOT_ApplicationUser", new object[] { "EOT-Realtime", "EOT-Timelapse", "Policies-Procedures", "Rosters-View", "Feedback-Submit" }}

        };

        public static string[] AccessRoles_ = new string[]
        {
            "TL_Developer", "TL_QA", "TSUP_Supervisor", "STA_DutyManager", "STA_Supervisor", "STA_Attendant",
            "TSO_Cooridinator", "TSO_Officer", "TSO_TCOMM", "TSO_SuperAdmin", "EOT_ApplicationUser", "PortalAppGuest"
        };


        static object[] EmployeeId = new string[]
        {
            //new object[] { "E0460", 209, "no error message" }
        };


        static string[] CancelledWhen = new string[]
        {
            "Yesterday", "Today"
        };

        static object[] StopNo =
        {
            new object[] { "50307" },
            new object[] { "51246" },
            new object[] { "50289" },
            new object[] { "58239" },
            new object[] { "54456" },
            new object[] { "54884" },
            new object[] { "52535" },
            new object[] { "54048" },

            new object[] { "55612" },
            new object[] { "55619" },
            //new object[] { "55618" },
            new object[] { "95618" }
        };

        static object[] RouteNo =
        {
            new object[] { "025" },
            new object[] { "020" },
            new object[] { "041" },
            new object[] { "099" },
            new object[] { "241" },
            new object[] { "340" },
            new object[] { "144" },
            new object[] { "212" },

            new object[] { "050" }
            //, new object[] { "" }
        };


        static object[] DateTime =
        {
            new object[] { Constants.timestamp },
            new object[] { "020" },
            new object[] { "041" },
            new object[] { "099" },
            new object[] { "241" },
            new object[] { "340" },
            new object[] { "144" },
            new object[] { "212" },

            new object[] { "050" }
            //, new object[] { "" }
        };


        static object[] Timeframe =
        {
            new object[] { "25" },
            new object[] { "30" },
            new object[] { "45" },
            new object[] { "15" },
            new object[] { "10" },
            new object[] { "60" },
            new object[] { "90" },
            new object[] { "110" },

            new object[] { "050" },
        };

        static object[] RouteNoPattern =
        {
            new object[] { "25", "WB1B5" },
            new object[] { "20", "SB1" },
            new object[] { "41", "W1" },
            new object[] { "99", "W1" },
            new object[] { "241", "EB1" },
            new object[] { "340", "WB1" },
            new object[] { "144", "NB1" },
            new object[] { "212", "E1" },

            new object[] { "050", "NB1WR" },
        };

        static object[] RouteNoTrip =
        {
            new object[] { "025", "9974040" },
            new object[] { "020", "9972117" },
            new object[] { "041", "9976027" },
            new object[] { "099", "9980337" },
            new object[] { "241", "" },
            new object[] { "340", "10002724" },
            new object[] { "144", "9986800" },
            new object[] { "212", "9993643" },

            new object[] { "050", "9977759" },
        };

        static object[] RouteNoDirection =
        {
            new object[] { "025", "West" },
            new object[] { "020", "South" },
            new object[] { "041", "West" },
            new object[] { "099", "East" },
            new object[] { "099", "West" },
            new object[] { "241", "South" },
            new object[] { "340", "East" },
            new object[] { "144", "North" },
            new object[] { "212", "East" },

            new object[] { "050", "South" },
        };


        static object[] Stop =
        {
            new object[] { "50307", "", "N", "", "", "", "49.250494", "-123.185062", "", "", "25" },
            new object[] { "51246", "", "", "", "", "", "49.226693", "-123.065819", "", "", "20" },
            new object[] { "50289", "", "", "", "", "", "49.234649", "-123.156193", "", "", "41" },
            new object[] { "58239", "", "", "", "", "", "49.263724", "-123.139158", "", "", "99" },
            new object[] { "54456", "", "", "", "", "", "49.322025", "-123.074863", "", "", "241" },
            new object[] { "54884", "", "", "", "", "", "49.119783", "-122.890201", "", "", "340" },
            new object[] { "52535", "", "", "", "", "", "49.26148", "-122.956905", "", "", "144" },
            new object[] { "54048", "", "", "", "", "", "49.315409", "-122.953404", "", "", "212" },

            new object[] { "55619", "SB 128 ST FS 102 AVE", "N", "SURREY", "128 ST", "102 AVE", "49.187744", "-122.867792", "1", "-1", "323, 393" },
            new object[] { "55618", "SB 128 ST FS 102 AVE", "N", "SURREY", "128 ST", "102 AVE", "49.187744", -122.867792, "1", "-1", "323, 393" }
        };

        //vehicle no from real time service
        static object[] BusId =
        {
            new object[] { "9523" },
            new object[] { "9552" },
            new object[] { "9742" },
            new object[] { "7191" },
            new object[] { "8102" },
            new object[] { "9435" },

            new object[] { "7196" },
            new object[] { "6140" }
        };

        static object[] StopNoRouteNo =
        {
            new object[] { "50307", "025" },
            new object[] { "51246", "020" },
            new object[] { "50289", "041" },
            new object[] { "58239", "099" },

            new object[] { "54456", "241" },

            new object[] { "54884", "340" },
            new object[] { "52535", "144" },
            new object[] { "54048", "212" },

            new object[] { "60980", "050" }
        };

        static object[] MLStopNoRouteNo =
        {
            new object[] { "50011", "006" },
            new object[] { "50954", "014" },
            new object[] { "60219", "014" },
            new object[] { "50077", "044" },
            new object[] { "58428", "095" },
            new object[] { "50319", "099" },
            new object[] { "59505", "187" },
            new object[] { "59990", "247" },
            new object[] { "61566", "257" },
            new object[] { "56151", "352" },
            new object[] { "58069", "410" },
            new object[] { "58432", "555" },
            //new object[] { "57500", "606" },
            new object[] { "57526", "606" },
            new object[] { "57614", "701" }

        };

        public static string[,] MLStopRouteTimes = new string[,]
        {
            /*
            { "50499", "095", "8:00am 8:05am 8:08am 8:13am 8:18am 8:22am 8:27am 8:31am 8:36am 8:40am 8:46am 8:50am 8:55am 8:59am 9:02am 9:04am 9:07am 9:11am 9:16am 9:21am 9:26am 9:31am 9:37am 9:45am 9:52am 10:00am 10:09am 10:17am 10:24am 10:32am 10:38am 10:46am 10:53am 11:01am 11:08am 11:16am 11:23am 11:31am 11:39am 11:47am 11:54am 12:02pm 12:06pm 12:14pm 12:21pm 12:29pm 12:36pm 12:44pm 12:51pm 12:59pm 1:06pm 1:14pm 1:21pm 1:29pm 1:36pm 1:44pm 1:51pm 1:59pm 2:05pm 2:13pm 2:20pm 2:28pm 2:32pm 2:36pm 2:44pm 2:51pm 2:59pm 3:06pm 3:14pm 3:21pm 3:29pm 3:36pm 3:41pm 3:44pm 3:51pm 3:59pm 4:06pm" },
            //{ "60248", "099", "8:01am 8:05am 8:08am 8:11am 8:14am 8:17am 8:20am 8:23am 8:26am 8:29am 8:32am 8:35am 8:38am 8:41am 8:44am 8:47am 8:50am 8:53am 8:56am 8:59am 9:03am 9:06am 9:09am 9:12am 9:15am 9:18am 9:21am 9:24am 9:28am 9:32am 9:36am 9:40am 9:44am 9:48am 9:52am 9:55am 10:00am 10:03am 10:07am 10:11am  10:15am 10:19am 10:23am 10:27am 10:33am 10:37am 10:42am 10:46am 10:51am 10:55am 11:00am 11:07am 11:12am 11:16am 11:21am 11:25am 11:30am 11:34am 11:40am 11:44am 11:49am 11:53am 11:58am 12:02pm 12:07pm 12:11pm 12:15pm 12:20pm 12:24pm 12:29pm 12:33pm 12:38pm 12:42pm 12:47pm 12:51pm 12:56pm 1:00pm 1:05pm 1:09pm 1:14pm 1:18pm 1:23pm 1:27pm 1:32pm 1:36pm 1:41pm 1:45pm 1:50pm 1:54pm 1:59pm 2:03pm 2:06pm 2:12pm 2:17pm 2:21pm 2:26pm 2:30pm 2:35pm 2:39pm 2:44pm 2:48pm 2:53pm 2:57pm 3:02pm 3:06pm 3:11pm 3:15pm 3:19pm 3:23pm 3:27pm 3:30pm 3:33pm 3:36pm 3:39pm 3:42pm 3:45pm 3:48pm 3:51pm 3:54pm 3:57pm 4:00pm 4:03pm" },
            { "58499", "099", "8:00am 8:04am 8:08am 8:11am 8:14am 8:17am 8:20am 8:23am 8:26am 8:29am 8:32am 8:35am 8:38am 8:41am 8:44am 8:47am 8:50am 8:53am 8:56am 8:59am 9:02am 9:07am 9:10am 9:13am 9:16am 9:19am 9:22am 9:25am 9:28am 9:32am 9:36am 9:40am 9:44am 9:48am 9:52am 9:56am 9:58am 10:04am 10:07am 10:11am 10:15am 10:19am 10:23am 10:27am 10:31am 10:37am 10:41am 10:46am 10:50am 10:55am 10:59am 11:04am 11:11am 11:16am 11:20am 11:25am 11:29am 11:34am 11:38am 11:44am 11:48am 11:53am 11:57am 12:02pm 12:06pm 12:11pm 12:15pm 12:19pm 12:24pm 12:28pm 12:33pm 12:37pm 12:42pm 12:46pm 12:51pm 12:55pm 1:00pm 1:04pm 1:09pm 1:13pm 1:18pm 1:22pm 1:27pm 1:31pm 1:36pm 1:40pm 1:45pm 1:49pm 1:54pm 1:58pm 2:03pm 2:07pm 2:10pm 2:16pm 2:21pm 2:25pm 2:30pm 2:34pm 2:39pm 2:43pm 2:48pm 2:52pm 2:57pm 3:01pm 3:06pm 3:10pm 3:15pm 3:19pm 3:23pm 3:27pm 3:31pm 3:34pm 3:37pm 3:40pm 3:43pm 3:46pm 3:49pm 3:52pm 3:55pm 3:58pm 4:01pm"},
            { "50601", "014", "8:08am 8:21am 8:33am 8:43am 8:53am 9:04am 9:14am 9:26am 9:36am 9:48am 10:00am 10:12am 10:24am 10:36am 10:48am 11:03am 11:15am 11:28am 11:40am 11:52am 12:04pm 12:16pm 12:28pm 12:40pm 12:52pm 1:05pm 1:17pm 1:29pm 1:41pm 1:53pm 2:05pm 2:17pm 2:29pm 2:36pm 2:41pm 2:50pm 2:53pm 3:05pm 3:15pm 3:20pm 3:25pm 3:35pm 3:45pm 3:47pm 3:49pm 3:52pm 3:54pm 3:57pm 3:59pm 4:05pm" },
            { "50949", "014", "8:08am 8:18am 8:27am 8:38am 8:50am 9:00am 9:12am 9:22am 9:33am 9:44am 9:55am 10:06am 10:18am 10:30am 10:43am 10:55am 11:06am 11:18am 11:30am 11:42am 11:55am 12:08pm 12:19pm 12:30pm 12:44pm 12:56pm 1:08pm 1:20pm 1:32pm 1:44pm 1:56pm 2:08pm 2:20pm 2:26pm 2:32pm 2:44pm 2:56pm 3:08pm 3:21pm 3:27pm 3:33pm 3:45pm 3:57pm 4:09pm 4:21pm" },
            { "59860", "006", "8:05am 8:10am 8:15am 8:20am 8:25am 8:31am 8:36am 8:41am 8:46am 8:51am 8:56am 9:01am 9:06am 9:11am 9:16am 9:23am 9:29am 9:36am 9:43am 9:51am 9:58am 10:06am 10:13am 10:21am 10:28am 10:36am 10:44am 10:52am 10:59am 11:07am 11:15am 11:23am 11:30am 11:38am 11:45am 11:53am 12:00pm 12:08pm 12:15pm 12:23pm 12:30pm 12:38pm 12:45pm 12:53pm 1:00pm 1:08pm 1:15pm 1:23pm 1:30pm 1:38pm 1:45pm 1:53pm 2:00pm 2:08pm 2:15pm 2:23pm 2:30pm 2:38pm 2:45pm 2:53pm 2:56pm 3:00pm 3:08pm 3:15pm 3:21pm 3:27pm 3:32pm 3:38pm 3:43pm 3:49pm 3:55pm 4:00pm 4:05pm" }
            */

            { "50590", "044", "8:04am 8:12am 8:20am 8:30am 8:38am 8:45am 8:51am 8:58am 9:04am 9:12am 9:23am 9:38am 9:53am 10:13am 10:33am 10:53am 11:13am 11:33am 11:53am 12:13pm 12:33pm 12:53pm 1:13pm 1:33pm 1:53pm 2:13pm 2:33pm 2:51pm 3:08pm 3:24pm 3:39pm 3:54pm" },
            { "50030", "044", "8:21am 8:39am 8:53am 9:05am 9:14am 9:22am 9:32am 9:42am 9:52am 10:04am 10:22am 10:42am 11:04am 11:24am 11:44am 12:05pm 12:25pm 12:45pm 1:05pm 1:25pm 1:45pm 2:05pm 2:25pm 2:45pm 3:05pm 3:25pm 3:42pm 3:55pm 4:01pm" },
            { "50052", "006", "8:04am 8:08am 8:13am 8:18am 8:22am 8:27am 8:32am 8:36am 8:41am 8:46am 8:50am 8:55am 8:59am 9:04am 9:09am 9:14am 9:19am 9:25am 9:31am 9:37am 9:43am 9:49am 9:56am 10:04am 10:11am 10:19am 10:26am 10:34am 10:41am 10:49am 10:56am 11:04am 11:11am 11:19am 11:26am 11:33am 11:40am 11:48am 11:55am 12:03pm 12:10pm 12:18pm 12:25pm 12:33pm 12:40pm 12:48pm 12:55pm 1:03pm 1:10pm 1:18pm 1:25pm 1:33pm 1:40pm 1:48pm 1:55pm 2:03pm 2:10pm 2:18pm 2:25pm 2:33pm 2:40pm 2:48pm 2:55pm 3:02pm 3:08pm 3:14pm 3:20pm 3:26pm 3:32pm 3:38pm 3:44pm 3:50pm 3:56pm 4:02pm" },
            { "51849", "095", "8:02am 8:06am 8:11am 8:15am 8:20am 8:24am 8:30am 8:34am 8:39am 8:43am 8:48am 8:52am 8:57am 9:01am 9:06am 9:10am 9:15am 9:19am 9:23am 9:27am 9:32am 9:37am 9:42am 9:47am 9:52am 9:57am 10:02am 10:07am 10:12am 10:17am 10:22am 10:28am 10:36am 10:43am 10:51am 11:00am 11:08am 11:15am 11:23am 11:30am 11:38am 11:45am 11:53am 12:00pm 12:08pm 12:15pm 12:23pm 12:31pm 12:39pm 12:46pm 12:54pm 1:01pm 1:09pm 1:16pm 1:24pm 1:31pm 1:39pm 1:46pm 1:54pm 2:03pm 2:11pm 2:18pm 2:26pm 2:33pm 2:41pm 2:48pm 2:56pm 3:00pm 3:08pm 3:15pm 3:23pm 3:27pm 3:35pm 3:42pm 3:50pm 3:57pm 4:01pm" },
            { "50499", "095", "8:00am 8:05am 8:08am 8:13am 8:18am 8:22am 8:27am 8:31am 8:36am 8:40am 8:46am 8:50am 8:55am 8:59am 9:02am 9:04am 9:07am 9:11am 9:16am 9:21am 9:26am 9:31am 9:37am 9:45am 9:52am 10:00am 10:09am 10:17am 10:24am 10:32am 10:38am 10:46am 10:53am 11:01am 11:08am 11:16am 11:23am 11:31am 11:39am 11:47am 11:54am 12:02pm 12:06pm 12:14pm 12:21pm 12:29pm 12:36pm 12:44pm 12:51pm 12:59pm 1:06pm 1:14pm 1:21pm 1:29pm 1:36pm 1:44pm 1:51pm 1:59pm 2:05pm 2:13pm 2:20pm 2:28pm 2:32pm 2:36pm 2:44pm 2:51pm 2:59pm 3:06pm 3:14pm 3:21pm 3:29pm 3:36pm 3:41pm 3:44pm 3:51pm 3:59pm 4:01pm" }
            /*
            { "58499", "099", "8:00am 8:04am 8:08am 8:11am 8:14am 8:17am 8:20am 8:23am 8:26am 8:29am 8:32am 8:35am 8:38am 8:41am 8:44am 8:47am 8:50am 8:53am 8:56am 8:59am 9:02am 9:07am 9:10am 9:13am 9:16am 9:19am 9:22am 9:25am 9:28am 9:32am 9:36am 9:40am 9:44am 9:48am 9:52am 9:56am 9:58am 10:04am 10:07am 10:11am 10:15am 10:19am 10:23am 10:27am 10:31am 10:37am 10:41am 10:46am 10:50am 10:55am 10:59am 11:04am 11:11am 11:16am 11:20am 11:25am 11:29am 11:34am 11:38am 11:44am 11:48am 11:53am 11:57am 12:02pm 12:06pm 12:11pm 12:15pm 12:19pm 12:24pm 12:28pm 12:33pm 12:37pm 12:42pm 12:46pm 12:51pm 12:55pm 1:00pm 1:04pm 1:09pm 1:13pm 1:18pm 1:22pm 1:27pm 1:31pm 1:36pm 1:40pm 1:45pm 1:49pm 1:54pm 1:58pm 2:03pm 2:07pm 2:10pm 2:16pm 2:21pm 2:25pm 2:30pm 2:34pm 2:39pm 2:43pm 2:48pm 2:52pm 2:57pm 3:01pm 3:06pm 3:10pm 3:15pm 3:19pm 3:23pm 3:27pm 3:31pm 3:34pm 3:37pm 3:40pm 3:43pm 3:46pm 3:49pm 3:52pm 3:55pm 3:58pm 4:01pm" },
            { "54441", "257", "8:13am 8:33am 8:53am 9:13am 9:33am 9:53am 10:13am 10:33am 10:53am 11:13am 11:33am 11:53am 12:13pm 12:28pm 12:48pm 1:08pm 1:28pm 1:48pm 2:08pm 2:28pm 2:48pm 3:08pm 3:28pm 3:48pm 4:08pm" },
            { "54411", "257", "8:01am 8:20am 8:35am 9:00am 9:25am 9:45am 10:00am 10:20am 10:40am 11:00am 11:25am 11:40am 12:05pm 12:20pm 12:40pm 1:00pm 1:20pm 1:40pm 2:00pm 2:20pm 2:40pm 3:00pm 3:20pm 3:40pm 4:05pm" },
            { "52095", "099", "8:02am 8:05am 8:08am 8:11am 8:14am 8:17am 8:20am 8:26am 8:29am 8:29am 8:35am 8:38am 8:41am 8:45am 8:47am 8:50am 8:53am 8:57am 9:00am 9:03am 9:06am 9:09am 9:12am 9:15am 9:18am 9:21am 9:24am 9:27am 9:30am 9:33am 9:36am 9:39am 9:43am 9:46am 9:50am 9:53am 9:57am 10:00am 10:04am 10:07am 10:11am 10:15am 10:19am 10:24am 10:28am 10:32am 10:37am 10:41am 10:45am 10:49am 10:54am 10:59am 11:03am 11:08am 11:12am 11:17am 11:21am 11:26am 11:30am 11:35am 11:39am 11:44am 11:48am 11:53am 11:57am 12:02pm 12:06pm 12:11pm 12:15pm 12:20pm 12:24pm 12:29pm 12:31pm 12:38pm 12:42pm 12:47pm 12:51pm 12:56pm 1:00pm 1:04pm 1:09pm 1:13pm 1:18pm 1:22pm 1:27pm 1:31pm 1:36pm 1:40pm 1:45pm 1:49pm  1:54pm 1:58pm 2:03pm 2:07pm 2:12pm 2:16pm 2:21pm 2:25pm 2:30pm 2:34pm 2:39pm 2:43pm 2:48pm 2:52pm 2:56pm 3:00pm 3:04pm 3:08pm 3:10pm 3:16pm 3:20pm 3:23pm 3:26pm 3:27pm 3:32pm 3:35pm 3:36pm 3:41pm 3:44pm 3:45pm 3:50pm 3:53pm 3:56pm 3:59pm 4:00pm 4:05pm" },
            { "58851", "187", "8:16am 8:33am 8:58am 9:27am 9:57am 10:27am 10:57am 11:27am 11:57am 12:27pm 12:57pm 1:27pm 1:57pm 2:30pm 3:00pm 3:30pm 3:45pm 4:00pm 4:20pm" },
            { "53929", "257", "8:10am 8:33am 8:50am 9:13am 9:42am 10:12am 10:42am 11:12am 11:42am 12:12pm 12:42pm 1:12pm 1:42pm 2:12pm 2:47pm 3:17pm 3:47pm 4:02pm" },
            { "61291", "701", "8:10am 8:27am 8:42am 8:59am 9:12am 9:25am 9:38am 9:53am 10:08am 10:23am 10:39am 10:53am 11:07am 11:22am 11:37am 11:52am 12:10pm 12:22pm 12:40pm 12:52pm 1:10pm 1:22pm 1:40pm 1:52pm 2:10pm 2:22pm 2:40pm 2:56pm 3:07pm 3:11pm 3:26pm 3:43pm 3:56pm 4:15pm" },
            { "61960", "555", "8:01am 8:06am 8:16am 8:26am 8:36am 8:46am 8:55am 9:09am 9:29am 9:49am 10:09am 10:29am 10:49am 11:09am 11:29am 11:49am 12:09pm 12:29pm 12:49pm 1:09pm 1:29pm 1:49pm 2:09pm 2:25pm 2:39pm 2:49pm 2:59pm 3:09pm 3:17pm 3:25pm 3:33pm 3:41pm 3:49pm 3:58pm 4:06pm" },
            { "61959", "555", "8:00am 8:05am 8:10am 8:15am 8:20am 8:25am 8:30am 8:35am 8:42am 8:49am 8:59am 9:09am 9:24am 9:44am 10:04am 10:24am 10:44am 11:04am 11:24am 11:44am 12:04pm 12:24pm 12:44pm 1:04pm 1:24pm 1:44pm 2:03pm 2:24pm 2:39pm 2:54pm 3:09pm 3:17pm 3:25pm 3:33pm 3:41pm 3:47pm 3:54pm 4:01pm" },
            { "57618", "257", "8:09am 8:13am 8:23am 8:58am 9:23am 9:54am 10:23am 10:51am 11:21am 11:53am 12:25pm 12:55pm 1:25pm 1:56pm 2:26pm 2:59pm 3:23pm 3:35pm 3:50pm 4:10pm" },
            { "56567", "410", "8:03am 8:09am 8:15am 8:21am 8:27am 8:33am 8:39am 8:45am 8:51am 8:57am  9:03am 9:09am 9:15am 9:21am 9:27am 9:33am 9:39am 9:46am 9:52am 10:02am 10:12am 10:22am 10:32am 10:42am 10:52am 11:02am 11:12am 11:22am 11:32am 11:42am 11:52am 12:02pm 12:12pm 12:22pm 12:32pm 12:42pm 12:52pm 1:02pm 1:12pm 1:22pm 1:32pm 1:42pm 1:52pm 2:02pm 2:12pm 2:22pm 2:32pm 2:42pm 2:52pm 3:02pm 3:12pm 3:22pm 3:28pm 3:40pm 3:45pm 3:52pm 3:59pm 4:07pm" },
            { "59555", "410", "8:03am 8:09am 8:15am 8:21am 8:28am 8:34am 8:40am 8:49am 8:55am 8:59am 9:05am 9:11am 9:18am 9:24am 9:30am 9:36am 9:42am 9:46am 9:52am 9:53am 9:59am 10:05am 10:11am 10:17am 10:23am 10:29am 10:37am 10:47am 10:57am 11:07am 11:17am 11:27am 11:37am 11:47am 11:57am 12:07pm 12:17pm 12:27pm 12:37pm 12:47pm 12:57pm 1:09pm 1:19pm 1:29pm 1:39pm 1:49pm 1:59pm 2:09pm 2:19pm 2:29pm 2:41pm 2:51pm 3:01pm 3:11pm 3:21pm 3:38pm 3:48pm 3:58pm 4:08pm" }
            */
        };

        public static object[] File =
        {
            new object[] { "rulebook", "rulebook.pdf", 200 },
            new object[] { "handbook", "Field Operations Handbook- PDF FINAL Sept 18, 2017.pdf", 200 },
            new object[] { "handbook", "Operations Handbook- PDF FINAL Sept 18, 2017.pdf", 204 },
            new object[] { "rulebook", "Oper", 204 }
        };

        public static object[] CIRList =
        {
            new object[] { -30, -10, "" },
            new object[] { -2, -1, "a" },
            new object[] { -5, -3, "b" },
        };

        public static object[] RouteMaps =
        {
            new object[] { "WEEKDAYS", "CONVENTIONAL" },
            new object[] { "SATURDAY", "CONVENTIONAL" },
            new object[] { "SUNDAY", "CONVENTIONAL" },

            new object[] { "WEEKDAYS", "COMMUNITY" },
            new object[] { "SATURDAY", "COMMUNITY" },
            new object[] { "SUNDAY", "COMMUNITY" },
 
            new object[] { "WEEKDAYS", "NIGHT BUS" },
            new object[] { "SATURDAY", "NIGHT BUS" },
            new object[] { "SUNDAY", "NIGHT BUS" },

            new object[] { "WEEKDAYS", "SERVICE NOT OPERATED BY CMBC" },
            new object[] { "SATURDAY", "SERVICE NOT OPERATED BY CMBC" },
            new object[] { "SUNDAY", "SERVICE NOT OPERATED BY CMBC" }

            /*
            new object[] { "all", "abc", "2019-12-0", "pn", "ps" },
            new object[] { "rejected", "abc", "2019-12-0", "pn", "ps" },
            new object[] { "pending", "abc", "2019-12-0", "pn", "ps" },*/
        };

        public static object[] Paddles =
        {
            new object[] { "WEEKDAYS", "CONVENTIONAL", "VTC" },
            new object[] { "SATURDAY", "CONVENTIONAL", "VTC" },
            new object[] { "SUNDAY", "CONVENTIONAL", "VTC" },

            new object[] { "WEEKDAYS", "CONVENTIONAL", "BTC" },
            new object[] { "SATURDAY", "CONVENTIONAL", "BTC" },
            new object[] { "SUNDAY", "CONVENTIONAL", "BTC" },

            new object[] { "WEEKDAYS", "CONVENTIONAL", "HTC" },
            new object[] { "SATURDAY", "CONVENTIONAL", "HTC" },
            new object[] { "SUNDAY", "CONVENTIONAL", "HTC" },

            new object[] { "WEEKDAYS", "CONVENTIONAL", "PCT" },
            new object[] { "SATURDAY", "CONVENTIONAL", "PCT" },
            new object[] { "SUNDAY", "CONVENTIONAL", "PCT" },

            new object[] { "WEEKDAYS", "CONVENTIONAL", "RTC" },
            new object[] { "SATURDAY", "CONVENTIONAL", "RTC" },
            new object[] { "SUNDAY", "CONVENTIONAL", "RTC" },

            new object[] { "WEEKDAYS", "CONVENTIONAL", "STC" },
            new object[] { "SATURDAY", "CONVENTIONAL", "STC" },
            new object[] { "SUNDAY", "CONVENTIONAL", "STC" },

            new object[] { "WEEKDAYS", "COMMUNITY", "XHT" },
            new object[] { "SATURDAY", "COMMUNITY", "XHT" },
            new object[] { "SUNDAY", "COMMUNITY", "XHT" },

            new object[] { "WEEKDAYS", "COMMUNITY", "XNE" },
            new object[] { "SATURDAY", "COMMUNITY", "XNE" },
            new object[] { "SUNDAY", "COMMUNITY", "XNE" },

            new object[] { "WEEKDAYS", "COMMUNITY", "XSS" },
            new object[] { "SATURDAY", "COMMUNITY", "XSS" },
            new object[] { "SUNDAY", "COMMUNITY", "XSS" },

        };

        public static object[] SecurityErrors =
        {
            new object[] { "", "Cyber Security Officer", "0730", "1315", "Car value must be present" },
            new object[] { "201", "", "0730", "1315", "Role value must be present" },

            new object[] { "201", "Cyber Security Officer", "073", "1315", "ShiftStartHour is not valid, must be a valid HHss" },
            new object[] { "201", "Cyber Security Officer", "", "1315", "ShiftStartHour must be present" },

            new object[] { "201", "Cyber Security Officer", "0730", "11", "ShiftEndHour is not valid, must be a valid HHss" },
            new object[] { "201", "Cyber Security Officer", "0730", "", "ShiftEndHour must be present" }

        };

        //add entry below to exclude from comparing the route, since ML there on all routes, commenting all
        public static string[] MLRoutes = new string[]
        { /*"006", "014", "044", "095", "099", "187", "247", "257", "352", "410", "555", "606", "701" */};

        static object[] Coordinates =
        {
            new object[] { "49.250494", "-123.185062" },
            new object[] { "49.226693", "-123.065819" },
            new object[] { "49.234649", "-123.156193" },
            new object[] { "49.263724", "-123.139158" },
            new object[] { "49.322025", "-123.074863" },
            new object[] { "49.119783", "-122.890201" },
            new object[] { "49.26148", "-122.956905" },
            new object[] { "49.315409", "-122.953404" },

            new object[] { "49.187706", "-122.850060" },
            new object[] { "49.187744", "-122.86779" },
            new object[] { "49.187744", "-122.86771" }
        };

        static object[] CoordinatesArea =
        {
            new object[] { "49.250494", "-123.185062", "49.260253", "-123.171865" },
            new object[] { "49.226693", "-123.065819", "49.229538", "-123.059671" },
            new object[] { "49.234649", "-123.156193", "49.238838", "-123.152792" },
            new object[] { "49.263724", "-123.139158", "49.266721", "-123.134351" },
            new object[] { "49.322025", "-123.074863", "49.325892", "-123.071108" },
            new object[] { "49.119783", "-122.890201", "49.127197", "-122.879418" },
            new object[] { "49.26148", "-122.956905", "49.266682", "-122.950081" },
            new object[] { "49.315409", "-122.953404", "49.320158", "-122.943383" },

            new object[] { "49.187706", "-122.850060", "49.192404", "-122.839127" },
            new object[] { "49.187744", "-122.86779", "49.194328", "-122.857619" },
            new object[] { "49.187744", "-122.86771", "49.196449", "-122.848030" }
        };

        static object[] CoordinatesRouteNo =
        {
            new object[] { "49.250494", "-123.185062", "025" },
            new object[] { "49.226693", "-123.065819", "020" },
            new object[] { "49.234649", "-123.156193", "041" },
            new object[] { "49.263724", "-123.139158", "099" },
            new object[] { "49.322025", "-123.074863", "241" },
            new object[] { "49.119783", "-122.890201", "340" },
            new object[] { "49.26148", "-122.956905", "144" },
            new object[] { "49.315409", "-122.953404", "212" },

            new object[] { "49.187706", "-122.850060", "590" },
            new object[] { "49.187744", "-122.867792", "323" },
            new object[] { "49.187744", "-122.867799", "393" }
        };

        static object[] CoordinatesRadius =
        {
            new object[] { "49.282667", "-123.117850", "200" },

            new object[] { "49.250494", "-123.185062", "100" },
            new object[] { "49.226693", "-123.065819", "50" },
            new object[] { "49.234649", "-123.156193", "33" },
            new object[] { "49.263724", "-123.139158", "46" },
            new object[] { "49.322025", "-123.074863", "25" },
            new object[] { "49.119783", "-122.890201", "18" },
            new object[] { "49.26148", "-122.956905", "14" },
            new object[] { "49.315409", "-122.953404", "140" },

            new object[] { "49.187706", "-122.850060", "50" },
            new object[] { "49.187744", "-122.867792", "70" },
            new object[] { "49.187744", "-122.867799", "110" }
        };

        static object[] CoordinatesRadiusGV =
        {
            //3km around arbutus Vancouver
            new object[] { "49.248631", "-123.166224", "2000" },

            //dt
            new object[] { "49.281423", "-123.124612", "2000" },

            //east side
            new object[] { "49.235969", "-123.082223", "2000" },

            //east side
            new object[] { "49.235969", "-123.082223", "2000" },

            //Burnaby
            new object[] { "49.252671", "-122.997166", "2000" },

            //New west
            new object[] { "49.213369", "-122.923695", "2000" },

            //Surrey
            new object[] { "49.171614", "-122.839858", "2000" },

            //Coquitlam
            new object[] { "49.271738", "-122.794476", "2000" }

        };

        static object[] StopCountTime =
        {
            new object[] { "50307", "3", "30", "25" },
            new object[] { "51246", "2", "15", "20" },
            new object[] { "50289", "5", "25", "41" },
            new object[] { "58239", "6", "36", "99" },
            new object[] { "54456", "5", "27", "241" },
            new object[] { "54884", "7", "45", "340" },
            new object[] { "52535", "3", "33", "144" },
            new object[] { "54048", "9", "27", "212" },

            new object[] { "55612", "3", "90", "050" },
            new object[] { "55619", "5", "30", "019" },
            new object[] { "55618", "7", "45", "106" }
        };

        static object[] Sms =
        {
            new object[] { "58239", "99" },

            new object[] { "50876", "" },
            new object[] { "50760", "480" }
        };

    }
}
