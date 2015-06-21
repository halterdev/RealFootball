using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RealFootball.Logic
{
    public class Game
    {
        // game variables
        private int homeTeamID, awayTeamID, quarter, minutes, seconds, 
            whoGotBallFirst, homeScore, awayScore;
        private bool isHomeTeamBall, isKickoff, isGameOver;
        private Random random;
        private int currentYardLine;
        private DataSet homeLineup, awayLineup;

        // new game created
        public Game(int homeTeamID, int awayTeamID)
        {
            this.homeTeamID = homeTeamID;
            this.awayTeamID = awayTeamID;
            quarter = 1;
            minutes = 15;
            homeScore = awayScore = seconds = 0;
            isKickoff = true;
            isGameOver = false;
            random = new Random();
            SetLineups();
            SimulateCoinToss();
            SimulateKickoff();
        }

        public void SimulateGame()
        {
            // opening kickoff has gone, let's roll...
            while (!isGameOver)
            {

            }
        }

        // get the home/away rosters
        private void SetLineups()
        {
            homeLineup = TeamLogic.GetTeamsStartingLineup(homeTeamID);
            awayLineup = TeamLogic.GetTeamsStartingLineup(awayTeamID);
        }
        private void SimulateCoinToss()
        {
            // 1 simulates home team
            int homeOrAway = random.Next(0, 1);
            isHomeTeamBall = (homeOrAway == 1);
            whoGotBallFirst = homeOrAway;
            if (whoGotBallFirst == 1)
            {
                currentYardLine = 35;
            }
            else
            {
                currentYardLine = 65;
            }
        }
        private void SimulateKickoff()
        {
            int kickYards = random.Next(50, 71);
            int returnYards = CalculateKickReturnYards();

            if (isHomeTeamBall)
            {
                // home team kicking
                currentYardLine += kickYards;
                if (currentYardLine > 100)
                {
                    // for now just touchback always if in endzone
                    currentYardLine = 80;
                }
                else
                {
                    // kick return
                    currentYardLine -= returnYards;
                }
            }
            else
            {
                // away team kicking
                currentYardLine -= kickYards;
                if (currentYardLine < 0)
                {
                    // for now just touchback always
                    currentYardLine = 20;
                }
                else
                {
                    // kick return
                    currentYardLine += returnYards;
                }
            }

            CalculateGameClock(returnYards / 3);
            isHomeTeamBall = !isHomeTeamBall;
            isKickoff = false;
        }
        
        
        // calculate yardline if number is over 50
        private int CalculateYardLine(int yardLine)
        {
            if (yardLine > 50)
            {
                int yardsOver = yardLine - 50;
                yardLine = 50 - yardsOver;
            }
            return yardLine;
        }
        
        // calculate the yards that a teams KR gets
        private int CalculateKickReturnYards()
        {
            // this is where i will check whether or not the home/away team is
            // receiving the ball... then check that teams KR, and do some # crunching
            // for now, however...
            return random.Next(10, 40);
        }

        // calculate the game clock
        private void CalculateGameClock(int seconds)
        {
            if (this.seconds == 0)
            {
                minutes--;
                if (minutes == 0)
                {
                    quarter++;
                    if (quarter > 4)
                    {
                        isGameOver = true;
                    }
                    else
                    {
                        minutes = 15;
                        seconds = 0;
                    }
                }
                else
                {
                    this.seconds = 59;
                    this.seconds -= seconds;
                }
            }
            else
            {
                this.seconds -= seconds;
                if (this.seconds < 0)
                {
                    minutes--;
                    if (minutes == 0)
                    {
                        quarter++;
                        if (quarter > 4)
                        {
                            isGameOver = true;
                        }
                        else
                        {
                            minutes = 15;
                            seconds = 0;
                        }
                    }
                    else
                    {
                        this.seconds = 59;
                        this.seconds += seconds;
                    }
                }
            }
        }
    }
}