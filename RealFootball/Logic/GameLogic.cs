using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealFootball.Logic
{
    public class GameLogic
    {
        public static Random random = new Random();

        public static void SimulateGame(int awayTeamID, int homeTeamID)
        {
            // game variables
            int quarter = 1;
            int minutes = 15;
            int seconds = 0;
            bool homeTeamBall = SimulateCoinToss();
            bool isKickoff = true;

            // while the game is not over...
            while (!(quarter == 4 && seconds == 0 && minutes == 0))
            {

            }
        }

        // coin toss returns true if home team wins and receives
        private static bool SimulateCoinToss()
        {
            // a 0 represents away, 1 represents home
            int homeOrAway = random.Next(0, 1);
            return homeOrAway == 1;
        }
    }
}