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
        //need to change these
        public static int play1hp = 7;
        public static int play2hp = 7;
        public static int play3hp = 7;
        public static int play4hp = 11;
        //sets the games and their variables for the first time when the game starts
        //sets them in the db which i will be pulling vars for the games 
        public static void GenerateInitialVars(int lobby)
        {
            Random rndm = new Random();
            for (int i = 0; i < 4; i++)
            {
                //ccan return 1,2,3 to pick which of the three games
                int whichgame = rndm.Next(1, 4);
                //store the game random numer in the array to put to the database
                //put the variable into the generate variables which returns vars for the game
                //depending on the game that you put in
                //and we will do this for each player since this is the initial game generating
                int[] mytempvars = MinigameVarGeneration.GenerateVariables(whichgame);
                //i is each player in this instance
                DBConnection.SetInitialGameVars(lobby,whichgame,mytempvars,i);


            }
        }
        //this is used to return coordinates for the html DIV mouse cursor for each player
        public static string GetPlayerMouse(GameVarModel gvm,DBGameVarModel dbgvm ,int whichplayer,string xory)
        {
            switch (whichplayer)
            {
                case 1:
                    if (xory == "x")
                    {
                        return (gvm.Width / 2) + dbgvm.P1Xcords+ "px";
                    }
                    else
                    {
                        return (gvm.Height / 2) + dbgvm.P1Ycords + "px";
                    }
                case 2:
                    if (xory == "x")
                    {
                        return ((gvm.Width / 2) + dbgvm.P2Xcords).ToString() + "px";
                    }
                    else
                    {
                        return ((gvm.Height / 2) + dbgvm.P2Ycords).ToString() + "px";
                    }
                case 3:
                    if (xory == "x")
                    {
                        return ((gvm.Width / 2) + dbgvm.P3Xcords).ToString() + "px";
                    }
                    else
                    {
                        return ((gvm.Height / 2) + dbgvm.P3Ycords).ToString() + "px";
                    }
                case 4:
                    if (xory == "x")
                    {
                        return ((gvm.Width / 2) + dbgvm.P4Xcords).ToString() + "px";
                    }
                    else
                    {
                        return ((gvm.Height / 2) + dbgvm.P4Ycords).ToString() + "px";
                    }
                default:
                    return "0px";
            }
        }
    }
}

