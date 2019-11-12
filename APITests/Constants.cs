using System;

namespace AppName
{
    public struct Constants
    {
         
        public const string environment = "stg"; //prd stg qa

        //EyesOnTransit
        public const string eotServerName = "servername.net";
        
        public const string apiKey = "apiKey";    //DEV
        public const string protocol = "https";

        public static string timestamp = DateTime.Now.ToString("yyyyMMdd_hhmmss");
        public static DateTime now = DateTime.Now;

    }
}