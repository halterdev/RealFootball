using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RealFootball
{
    public class Main
    {
        #region *** CONSTANTS ***
        // player generation
        public static string[] FIRSTNAMES = { "Jim", "Jack", "Joe", "Brad", "Barry", "Mike", "Larry",
                                                "Luke", "Sam", "Ryan", "Sean", "Matthew", "Doug", "Peter", "Pete",
                                                "Harold", "Greg", "Jeff", "Vince", "Barry", "Walt", "Tim", "Anthony",
                                                "Tony", "Owen", "Frank", "Fred", "George", "Michael", "Mark",
                                                "Mack", "Brett", "Ant", "Daniel", "Steven", "Warren", "Tom", "Andy", "Terry"}; // 39 names
        public static string[] LASTNAMES = { "Halter", "Morrow", "Bradway", "Holtz", "Walter", "Peter", "Gregg",
                                                "Park", "Smith", "Houdini", "Holmes", "Black", "White", "Brown",
                                                "Dietrich", "Diekman", "Bonds", "McCoy", "Adams", "Samuels", "Marks",
                                                "Ryans", "Reed", "Reid", "Waltz", "Phillips", "Boyle", "Whitman", "Obama",
                                                "Nixon", "Thompson", "Dougan", "Hohing", "Quinn", "Foles", "Barkley", "Vick", 
                                                "Vincent", "Jackson"}; // 39 names

        public static string[] HOMETOWNS = { "Pedricktown", "Penns Grove", "Philadelphia", "Los Angeles", "Tampa Bay" };
        public static string[] STATES = { "New Jersey", "New Jersey", "Pennsylvania", "California", "Florida" };
        public static string[] COLLEGES = {"Rowan University", "Rutgers University", "University of Miami", "Ohio State University",
                                              "Notre Dame", "University of Michigan", "Michigan State University", "University of Florida"};
        public static int BEGINYEAR = 1978;
        public static int ENDYEAR = 1991;
        public static int MINFEET = 5;
        public static int MAXFEET = 7;
        public static int MININCHES = 1;
        public static int MAXINCHES = 11;
        public static int MINWEIGHT = 150;
        public static int MAXWEIGHT = 310;
        public static int MINRATING = 1;
        public static int MAXRATING = 100;

        public static int MINCORERATING = 32;
        public static int MAXNONCORERATING = 60;
        public static int MAXMINWEIGHT = 250;

        // team generation
        public static int NUMBEROFPLAYERS = 70;

        public static int MINQUARTERBACKS = 3;
        public static int MINRUNNINGBACKS = 5;
        public static int MINWIDERECEIVERS = 7;
        public static int MINOFFENSIVELINEMAN = 8;
        public static int MINFULLBACKS = 1;
        public static int MINTIGHTENDS = 2;

        public static int MINCORNERBACKS = 6;
        public static int MINOUTSIDELINEBACKERS = 3;
        public static int MINMIDDLELINEBACKERS = 2;
        public static int MINDEFENSIVELINEMAN = 8;
        public static int MINSAFETIES = 3;

        public static int MINKICKERS = 1;
        public static int MINPUNTERS = 1;

        public static int FIRSTTEAMDETAIL = 17;
        public static int LASTTEAMDETAIL = 48;

        // conference numbers
        public static int NFC = 1;
        public static int AFC = 2;

        // division numbers
        public static int NFCEAST = 1;
        public static int AFCEAST = 2;
        public static int NFCNORTH = 3;
        public static int AFCNORTH = 4;
        public static int NFCSOUTH = 5;
        public static int AFCSOUTH = 6;
        public static int NFCWEST = 7;
        public static int AFCWEST = 8;

        // league types
        public static int ONE = 1;

        // positions
        public static int QUARTERBACK = 1;
        public static int RUNNINGBACK = 2;
        public static int WIDERECEIVER = 3;
        public static int TIGHTEND = 4;
        public static int FULLBACK = 5;
        public static int OFFENSIVELINEMAN = 6;
        public static int DEFENSIVELINEMAN = 7;
        public static int CORNERBACK = 8;
        public static int SAFETY = 9;
        public static int OUTSIDELINEBACKER = 10;
        public static int MIDDLELINEBACKER = 11;
        public static int KICKER = 12;
        public static int PUNTER = 13;

        // game constants
        public static int KICKOFFFROM = 35;
        #endregion

        // generate a random date (day/month/year) given a year range
        public static DateTime GetRandomDate(int startYear, int endYear)
        {
            Random random = new Random();
            int year = random.Next(startYear, endYear);
            int month = random.Next(1, 12);
            int day = DateTime.DaysInMonth(year, month);
            day = random.Next(1, day);
            DateTime date = new DateTime(year, month, day);
            return date;
        }

        // return connection string for sqlconnection
        public static string GetDSN()
        {
            return WebConfigurationManager.ConnectionStrings["connString"].ToString();
        }

    }
}