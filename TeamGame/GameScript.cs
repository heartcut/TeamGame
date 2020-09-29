using TeamGame.MinigameComps;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TeamGame.SqlAccess;
using TeamGame.SqlAccess.GameStateModels;
using Microsoft.AspNetCore.Components;
using TeamGame.PlayerHealthBar;
using System.Runtime.CompilerServices;
using System.Data;
using Microsoft.VisualBasic;
using TeamGame.Pages;

namespace TeamGame
{

    public class GameScript
    {
        public static string GetPlayerMouse(GameVarModel gvm,DBGameVarModel dbgvm ,int whichplayer,string xory)
        {
            switch (whichplayer)
            {
                case 1:
                    if (xory == "x")
                    {
                        return (gvm.Width / 2) + dbgvm.P1Xcords +50+ "px";
                    }
                    else
                    {
                        return (gvm.Height / 2) + dbgvm.P1Ycords +50+ "px";
                    }
                case 2:
                    if (xory == "x")
                    {
                        return (gvm.Width / 2) + dbgvm.P2Xcords + "px";
                    }
                    else
                    {
                        return (gvm.Height / 2) + dbgvm.P2Ycords + "px";
                    }
                case 3:
                    if (xory == "x")
                    {
                        return (gvm.Width / 2) + dbgvm.P3Xcords + "px";
                    }
                    else
                    {
                        return (gvm.Height / 2) + dbgvm.P3Ycords + "px";
                    }
                case 4:
                    if (xory == "x")
                    {
                        return (gvm.Width / 2) + dbgvm.P4Xcords + "px";
                    }
                    else
                    {
                        return (gvm.Height / 2) + dbgvm.P4Ycords + "px";
                    }
                default:
                    return "0px";
            }
        }
        

        //i will use the below to choose which game im playing locally
        //public static string GetMyGame()
        //{
        //    mycurrentgame = "sng";
        //    return "sng";
        //}
        //public static string GetGame()
        //{
        //    if (GetMyGame() == "sng")
        //    {
        //        return "sixninegame";
        //    }
        //    return "idk";
        //}
        //this will be used to get other players games and update your ui
        //public static string GetPlayerGame(int a)
        //{
        //    if (a == 1)
        //    {
        //        return p1currentgame;
        //    }
        //    if (a == 2)
        //    {
        //        return p2currentgame;
        //    }
        //    if (a == 3)
        //    {
        //        return p3currentgame;
        //    }
        //    if (a == 4)
        //    {
        //        return p4currentgame;
        //    }
        //    return "sorry you got an error bud";
        //}

        public static int play1hp = 7;
        public static int play2hp = 7;
        public static int play3hp = 7;
        public static int play4hp = 11;

        public static string Coordinates { get; set; }
        //public static double cursx { get; set; }
        //public static double cursy { get; set; }
        //public static double cursxx { get; set; }
        //public static double cursyy { get; set; }


        //public static void Player1MouseMoved(MouseEventArgs e)
        //{
        //    //this sets curs to the coords around the center bascially
        //    cursx = e.ClientX-(GamePage.Width/2);
        //    cursy = e.ClientY-(GamePage.Height/2);
        //    cursxx = e.ClientX;
        //    cursyy = e.ClientY;
        //}
    }


    public class TestClass
    {
        

        internal SixNineGame sng1 = new SixNineGame();
        internal SixNineGame sng2 = new SixNineGame();
        internal SixNineGame sng3 = new SixNineGame();
        internal SixNineGame sng4 = new SixNineGame();
        
        public Player1HealthBar p1hp;
        public Player2HealthBar p2hp;
        public Player3HealthBar p3hp;
        public Player4HealthBar p4hp;

        public static int play1hp = 11;
        public static int play2hp = 11;
        public static int play3hp = 11;
        public static int play4hp = 11;
        public void HealthMinus(int a)
        {
            if (a == 1)
            {
                TestClass.play1hp--;
            }
            if (a == 2)
            {
                TestClass.play2hp--;

            }
            if (a == 3)
            {
                TestClass.play3hp--;
            }
            if (a == 4)
            {
                TestClass.play4hp--;
            }
        }
        public void HealthPlus(int a)
        {
            if (a == 1)
            {
                TestClass.play1hp++;
            }
            if (a == 2)
            {
                TestClass.play2hp++;
            }
            if (a == 3)
            {
                TestClass.play3hp++;
            }
            if (a == 4)
            {
                TestClass.play4hp++;
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /// below is the sql stuff
        /// </summary>
        //create list of type personmodel named people
        //list is not instanciated right away
        public List<GameVarModel> GameVars;
        //instanciated right away with DisplaypersonMOdel() at end
    }

    //------game with all players together to count to twenty-----------

    public class TeamNumGame
    {
        public int totwenty = 0;
    }

    //------all the individual games below---------

}

