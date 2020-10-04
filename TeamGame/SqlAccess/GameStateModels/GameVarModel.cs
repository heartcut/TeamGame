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
        public int PlayerIAm { get; set; }
        public int MyLobby { get; set; }
        
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
        //vars i will need to push in the future
        public int MyCurrentGame = 1;
        public int MyGameVars;

    }
}  
