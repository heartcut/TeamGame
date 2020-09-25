﻿using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamGame.Pages;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class MyVarsGetter
    {   
        
        private int MyLobbyNumber;
        private int MyPlayerNumber;
        public MyVarsGetter(int LobbyNumber,int playernumber)
        {
            MyLobbyNumber = LobbyNumber;
            MyPlayerNumber = playernumber;
        }
        public List<GameVarModel> GameVars;

        public string p1currentgame;
        public string p2currentgame;
        public string p3currentgame;
        public string p4currentgame = "sng";
        //takes players game you want number as i nt
        public string GetPlayerGame(int a)
        {
            if (a == 1)
            {
                return p1currentgame;
            }
            if (a == 2)
            {
                return p2currentgame;
            }
            if (a == 3)
            {
                return p3currentgame;
            }
            if (a == 4)
            {
                return p4currentgame;
            }
            return "sorry you got an error bud";
        }

        public static double cursx { get; set; }
        public static double cursy { get; set; }
        //this gets my mouse coords and sets the cursxy vars to px from the center
        public void MyMousePos(MouseEventArgs e)
        {
            //this sets curs to the coords around the center bascially
            cursx = e.ClientX - (GamePage.Width / 2);
            cursy = e.ClientY - (GamePage.Height / 2);
        }
        //js testing
        //vars i get from the broswerservice
        //TeamGame.JavaScript.BrowserService
        public int Height { get; set; }
        public int Width { get; set; }
        //internal can only be used by objects made from the class
        //these functions can return the players mouse from db with coords form the center and convert
        //to my screen size
        //first parameter is the player number second is "X" or "Y"
        internal string GetPlayerCoords(int player, string xory)
        {
            if (this.GameVars is null)
            {
                return "0";
            }
            else
            {
                if (player==1)
                {
                    if (xory == "X")
                    {
                        return ((this.Width / 2) + (this.GameVars[0].P1Xcords)) + "px";
                    }
                    else
                    {
                        return ((this.Height / 2) + (this.GameVars[0].P1Ycords)) + "px";
                    }
                }
                else if (player==2)
                {
                    if (xory == "X")
                    {
                        return ((this.Width / 2) + (this.GameVars[0].P2Xcords)) + "px";
                    }
                    else
                    {
                        return ((this.Height / 2) + (this.GameVars[0].P2Ycords)) + "px";
                    }
                }
                else if (player==3)
                {
                    if (xory == "X")
                    {
                        return ((this.Width / 2) + (this.GameVars[0].P3Xcords)) + "px";
                    }
                    else
                    {
                        return ((this.Height / 2) + (this.GameVars[0].P3Ycords)) + "px";
                    }
                }
                else //player==4
                {
                    if (xory == "X")
                    {
                        return ((this.Width / 2) + (this.GameVars[0].P4Xcords)) + "px";
                    }
                    else
                    {
                        return ((this.Height / 2) + (this.GameVars[0].P4Ycords)) + "px";
                    }
                }
            }
        }
        internal void ILostHealth(int Lobby,int Player)
        {

        }
        internal void IGaveMyPartnerHealth(int Lobby, int Player)
        {

        }


    }
}