using System;
using System.Collections;
using System.Collections.Generic;

namespace PortalApp
{

    public struct Constants
    {
         
        public const string environment = "stg"; //prd stg qa

        //EyesOnTransit
        public const string portalServerName = "translink-dev.azure-api.net";
        
        public const string rttiServerName = "rtti-ride-dev.translink.ca"; //DEV "rtti-api-dev.azurewebsites.net";
        public const string apiKey = "40635b3b66c34ae0942c0667ff5899b3";    //DEV
        public const string protocol = "https";

        public const string rttiDatabaseServer = "glcstgsqltranslinkrtti";
        public const string rttiDatabase = "STG01-SDB-RTTI"; //"PRD01-SDB-RTTI";

        public static string timestamp = DateTime.Now.ToString("yyyyMMdd_hhmmss");
        public static DateTime now = DateTime.Now;
        public static string perfLog = "perfLog.csv";

        //App specific
        public const string incidentReportVersion = "1";
        public const string authorizationVersion = "1";
        public const string securityRosterVersion = "1";
        public const string fileVersion = "1";
        public const string cirListVersion = "1";

        public static int[] trainLine = new int[] { 0, 1, 3, 952, 1581, 1612};

        /*
        // single-dimension jagged array
        var c = new[]
        {
            new[]{1,2,3,4},
            new[]{5,6,7,8}
        };*/

        public static string[,] stationInfo =
        {
                {   "1", "Waterfront Inbound", "WFI"},
                {   "2", "Waterfront Outbound", "WFO"},
                {   "3", "Burrard Inbound", "BUI"},
                {   "4", "Burrard Outbound", "BUO"},
                {   "5", "Granville Inbound", "GVI"},
                {   "6", "Granville Outbound", "GVO"},
                {   "7", "Stadium Inbound", "STI"},
                {   "8", "Stadium Outbound", "STO"},
                {  "10", "Main Street Inbound", "MNI"},
                {  "11", "Main Street Outbound", "MNO"},
                {  "12", "Broadway Inbound", "BWI"},
                {  "13", "Broadway Outbound", "BWO"},
                {  "14", "Nanaimo Inbound", "NAI"},
                {  "15", "Nanaimo Outbound", "NAO"},
                {  "16", "Twenty-Ninth Inbound", "TNI"},
                {  "17", "Twenty-Ninth Outbound", "TNO"},
                {  "18", "Joyce Inbound", "JYI"},
                {  "19", "Joyce Outbound", "JYO"},
                {  "20", "Patterson Inbound", "PTI"},
                {  "21", "Patterson Outbound", "PTO"},
                {  "22", "Meterotown Inbound", "MTI"},
                {  "23", "Metrotown Outbound", "MTO"},
                {  "24", "Royal Oak Inbound", "ROI"},
                {  "25", "Royal Oak Outbound", "ROO"},
                {  "26", "Edmonds Inbound", "EDI"},
                {  "27", "Edmonds Outbound", "EDO"},
                {  "28", "Twenty-Second Inbound", "TSI"},
                {  "29", "Twenty-Second Outbound", "TSO"},
                {  "30", "New Westminster Inbound", "NWI"},
                {  "31", "New Westminster Outbound", "NWO"},
                {  "32", "Columbia Inbound", "COI"},
                {  "33", "Columbia Outbound", "COO"},
                {  "34", "Scott Road Inbound", "SRI"},
                {  "35", "Scott Road Outbound", "SRO"},
                {  "36", "Gateway Inbound", "GWI"},
                {  "37", "Gateway Outbound", "GWO"},
                {  "38", "Surrey Central Inbound", "SCI"},
                {  "39", "Surrey Central Outbound", "SCO"},
                {  "40", "King George Inbound", "KGI"},
                {  "41", "King George Outbound", "KGO"},
                {  "79", "Sapperton Inbound", "SAI"},
                {  "80", "Sapperton Outbound", "SAO"},
                {  "81", "Braid Inbound", "BDI"},
                {  "82", "Braid Outbound", "BDO"},
                {  "83", "Lougheed Inbound", "LHI"},
                //{   "Lougheed Outbound", "LHO"},
                {  "85", "Lougheed Side Track", "LHS"},
                {  "86", "Production Way Inbound", "PWI"},
                {  "87", "Production Way Outbound", "PWO"},
                {  "88", "Lake City Way Inbound", "LCI"},
                {  "89", "Lake City Way Outbound", "LCO"},
                {  "90", "Sperling Inbound", "SPI"},
                //{  "91", "Sperling Outbound", "SPO"},
                {  "92", "Holdom Inbound", "HDI"},
                {  "93", "Holdom Outbound", "HDO"},
                {  "94", "Brentwood Inbound", "BRI"},
                {  "95", "Brentwood Outbound", "BRO"},
                {  "96", "Gilmore Inbound", "GMI"},
                {  "97", "Gilmore Outbound", "GMO"},
                {  "98", "Rupert Inbound", "RUI"},
                {  "99", "Rupert Outbound", "RUO"},
                { "100", "Renfrew Inbound", "REI"},
                { "101", "Renfrew Outbound", "REO"},
                { "102", "Commercial Inbound", "CMI"},
                { "103", "Commercial Outbound", "CMO"},
                { "104", "VCC Inbound", "VCI"},
                { "105", "VCC Outbound", "VCO"},
                { "130", "Burquitlam Inbound", "BQI"},
                { "131", "Burquitlam Outbound", "BQO"},
                { "134", "Moody Centre Inbound", "MCI"},
                { "135", "Moody Centre Outbound", "MCO"},
                { "136", "Inlet Centre Inbound", "ICI"},
                { "137", "Inlet Centre Outbound", "ICO"},
                { "140", "Coquitlam Central Inbound", "CCI"},
                { "141", "Coquitlam Central Outbound", "CCO"},
                { "142", "Lincoln Inbound", "LNI"},
                { "143", "Lincoln Outbound", "LNO"},
                { "144", "Lafarge Lake Inbound", "LAI"},
        };

        public static object[] stationInfo_ =
        {
            //new object[] {"2019-12-0", "", "pn", "ps"},
            //new object[] {"2019-12-0", "", "1", "ps"}

                new object[] {   1, "Waterfront Inbound", "WFI"},
                new object[] {   2, "Waterfront Outbound", "WFO"},
                new object[] {   3, "Burrard Inbound", "BUI"},
                new object[] {   4, "Burrard Outbound", "BUO"},
                new object[] {   5, "Granville Inbound", "GVI"},
                new object[] {   6, "Granville Outbound", "GVO"},
                new object[] {   7, "Stadium Inbound", "STI"},
                new object[] {   8, "Stadium Outbound", "STO"},
                new object[] {  10, "Main Street Inbound", "MNI"},
                new object[] {  11, "Main Street Outbound", "MNO"},
                new object[] {  12, "Broadway Inbound", "BWI"},
                new object[] {  13, "Broadway Outbound", "BWO"},
                new object[] {  14, "Nanaimo Inbound", "NAI"},
                new object[] {  15, "Nanaimo Outbound", "NAO"},
                new object[] {  16, "Twenty-Ninth Inbound", "TNI"},
                new object[] {  17, "Twenty-Ninth Outbound", "TNO"},
                new object[] {  18, "Joyce Inbound", "JYI"},
                new object[] {  19, "Joyce Outbound", "JYO"},
                new object[] {  20, "Patterson Inbound", "PTI"},
                new object[] {  21, "Patterson Outbound", "PTO"},
                new object[] {  22, "Meterotown Inbound", "MTI"},
                new object[] {  23, "Metrotown Outbound", "MTO"},
                new object[] {  24, "Royal Oak Inbound", "ROI"},
                new object[] {  25, "Royal Oak Outbound", "ROO"},
                new object[] {  26, "Edmonds Inbound", "EDI"},
                new object[] {  27, "Edmonds Outbound", "EDO"},
                new object[] {  28, "Twenty-Second Inbound", "TSI"},
                new object[] {  29, "Twenty-Second Outbound", "TSO"},
                new object[] {  30, "New Westminster Inbound", "NWI"},
                new object[] {  31, "New Westminster Outbound", "NWO"},
                new object[] {  32, "Columbia Inbound", "COI"},
                new object[] {  33, "Columbia Outbound", "COO"},
                new object[] {  34, "Scott Road Inbound", "SRI"},
                new object[] {  35, "Scott Road Outbound", "SRO"},
                new object[] {  36, "Gateway Inbound", "GWI"},
                new object[] {  37, "Gateway Outbound", "GWO"},
                new object[] {  38, "Surrey Central Inbound", "SCI"},
                new object[] {  39, "Surrey Central Outbound", "SCO"},
                new object[] {  40, "King George Inbound", "KGI"},
                new object[] {  41, "King George Outbound", "KGO"},
                new object[] {  79, "Sapperton Inbound", "SAI"},
                new object[] {  80, "Sapperton Outbound", "SAO"},
                new object[] {  81, "Braid Inbound", "BDI"},
                new object[] {  82, "Braid Outbound", "BDO"},
                new object[] {  83, "Lougheed Inbound", "LHI"},
                //new object[] {   "Lougheed Outbound", "LHO"},
                new object[] {  85, "Lougheed Side Track", "LHS"},
                new object[] {  86, "Production Way Inbound", "PWI"},
                new object[] {  87, "Production Way Outbound", "PWO"},
                new object[] {  88, "Lake City Way Inbound", "LCI"},
                new object[] {  89, "Lake City Way Outbound", "LCO"},
                new object[] {  90, "Sperling Inbound", "SPI"},
                //new object[] {  91, "Sperling Outbound", "SPO"},
                new object[] {  92, "Holdom Inbound", "HDI"},
                new object[] {  93, "Holdom Outbound", "HDO"},
                new object[] {  94, "Brentwood Inbound", "BRI"},
                new object[] {  95, "Brentwood Outbound", "BRO"},
                new object[] {  96, "Gilmore Inbound", "GMI"},
                new object[] {  97, "Gilmore Outbound", "GMO"},
                new object[] {  98, "Rupert Inbound", "RUI"},
                new object[] {  99, "Rupert Outbound", "RUO"},
                new object[] { 100, "Renfrew Inbound", "REI"},
                new object[] { 101, "Renfrew Outbound", "REO"},
                new object[] { 102, "Commercial Inbound", "CMI"},
                new object[] { 103, "Commercial Outbound", "CMO"},
                new object[] { 104, "VCC Inbound", "VCI"},
                new object[] { 105, "VCC Outbound", "VCO"},
                new object[] { 130, "Burquitlam Inbound", "BQI"},
                new object[] { 131, "Burquitlam Outbound", "BQO"},
                new object[] { 134, "Moody Centre Inbound", "MCI"},
                new object[] { 135, "Moody Centre Outbound", "MCO"},
                new object[] { 136, "Inlet Centre Inbound", "ICI"},
                new object[] { 137, "Inlet Centre Outbound", "ICO"},
                new object[] { 140, "Coquitlam Central Inbound", "CCI"},
                new object[] { 141, "Coquitlam Central Outbound", "CCO"},
                new object[] { 142, "Lincoln Inbound", "LNI"},
                new object[] { 143, "Lincoln Outbound", "LNO"},
                new object[] { 144, "Lafarge Lake Inbound", "LAI"},
        };

    }
}