﻿using TeamGame.MinigameComps;
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
        public static int[] GetPlayerGameAndVars()
        {
            Random rmd = new Random();
            //next returns 1,2, or 3
            //1 -sixnine/2-makeasquare/3-memcolornum
            //int whatgame = rmd.Next(1, 4);
            int[] myarr = new int[3];
            int whatgame = 1;
            if (whatgame == 1)
            {
                int[] GameVars = SixNineGame.RandomSixesV2();
                myarr= GameVars;
            }
            else if (whatgame == 2)
            {
                //makeasquare
            }
            else if (whatgame == 3)
            {
                //mem colornum
            }
            //i will hold which game and the variables that go with it here
            
            return myarr;
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

