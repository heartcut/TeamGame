using Dapper;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TeamGame.MinigameComps;
using TeamGame.PlayerHealthBar;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class GameVarModel
    {
        //local vars i will be pushing
        public double mycursx { get; set; }
        public double mycursy { get; set; }
        //js testing
        //vars i get from the broswerservice
        //TeamGame.JavaScript.BrowserService
        public int Height { get; set; }
        public int Width { get; set; }
        public void MouseMoved(MouseEventArgs e)
        {
            //this sets curs to the coords around the center bascially
            mycursx = e.ClientX - (Width / 2);
            mycursy = e.ClientY - (Height / 2);
        }
        public string MyCurrentGame = "my game here";
        //db vars i will be pulling
        public string LobbyNumber { get; set; }

        public string PlayersInLobby { get; set; }

        public string P1Game { get; set; }
        public string P2Game { get; set; }
        public string P3Game { get; set; }
        public string P4Game { get; set; }

        public double P1Xcords { get; set; }
        public double P1Ycords { get; set; }
        public double P2Xcords { get; set; }
        public double P2Ycords { get; set; }
        public double P3Xcords { get; set; }
        public double P3Ycords { get; set; }
        public double P4Xcords { get; set; }
        public double P4Ycords { get; set; }

        public int P1Health { get; set; }
        public int P2Health { get; set; }
        public int P3Health { get; set; }
        public int P4Health { get; set; }

       

        public string P1Present { get; set; }
        public string P2Present { get; set; }
        public string P3Present { get; set; }
        public string P4Present { get; set; }

        

    }
}  
