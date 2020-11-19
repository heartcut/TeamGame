using Dapper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TeamGame.SqlAccess.GameStateModels;

namespace TeamGame.SqlAccess
{
    public class DBConnection
    {
        //this just takes a lobbynumber and checks if the playersinlobby var in that row is under 4
        //and returns true or false accordingly
        //no longer use this
        //todo maybe delete
        //public static bool CheckLobby(int lobnumber)
        //{
        //    var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

        //    using var con = new SqlConnection(cs);
        //    con.Open();
        //    //new id 3 means making a new car object with the id = to 3??
        //    int players = con.QueryFirst<int>(@"SELECT PlayersInLobby FROM CursorPos WHERE LobbyNumber=" + lobnumber);
        //    bool canjoin;
        //    if (players < 4)
        //    {
        //        canjoin = true;
        //    }
        //    else
        //    {
        //        canjoin = false;
        //    }
        //    con.Dispose();

        //    return canjoin;
        //}
        public static NavigationManager navManager;
        public static int IJoined(int lobnumber)
        {
            //uncomment to get the lobby players stuff working
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);
            con.Open();
            //new id 3 means making a new car object with the id = to 3??
            //DBGameVarModel GVM = new DBGameVarModel();
            int players = con.QueryFirst<int>(@"SELECT PlayersInLobby FROM CursorPos WHERE LobbyNumber=" + lobnumber);
            //int players = GVM.PlayersInLobby;
            if (players == 0)
            {
                players++;
                con.Execute("UPDATE CursorPos SET PlayersInLobby =" + players + " WHERE LobbyNumber = " + lobnumber + "; ");
                return 1;
            }
            else if (players == 1)
            {
                players++;
                con.Execute("UPDATE CursorPos SET PlayersInLobby =" + players + " WHERE LobbyNumber = " + lobnumber + "; ");
                return 2;
            }
            else if (players == 2)
            {
                players++;
                con.Execute("UPDATE CursorPos SET PlayersInLobby =" + players + " WHERE LobbyNumber = " + lobnumber + "; ");
                return 3;
            }
            else if (players == 3)
            {
                players++;
                con.Execute("UPDATE CursorPos SET PlayersInLobby =" + players + " WHERE LobbyNumber = " + lobnumber + "; ");
                return 4;
            }
            else
            {
                navManager.NavigateTo("/lobbyfull");
                return 0;
            }
        }
        public static void ILeft(int lobnumber)
        {
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);
            con.Open();
            //new id 3 means making a new car object with the id = to 3??
            int players = con.QueryFirst<int>(@"SELECT PlayersInLobby FROM CursorPos WHERE LobbyNumber=" + lobnumber);
            players--;
            con.Execute("UPDATE CursorPos SET PlayersInLobby = "+players+", GameStarted = 0 WHERE LobbyNumber = " + lobnumber + "; ");
            
            con.Dispose();

        }

        public static void SetInitialGameVars(int lobnumber,int whichgame,int[] vars,int whichplayer)
        {
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);
            con.Open();
            con.Execute("UPDATE CursorPos SET P"+(whichplayer+1)+"Game =" + whichgame +
                ", P"+(whichplayer+1)+"GameVar1 = " + vars[0] +
                ", P" + (whichplayer + 1) + "GameVar2 = " + vars[1] +
                ", P" + (whichplayer + 1) + "GameVar3 = " + vars[2] +
                ", P" + (whichplayer + 1) + "GameVar4 = " + vars[3] +
                ", GameStarted = 1 " +
                " WHERE LobbyNumber = " + lobnumber + "; ");
            //todo with the game start somewhere else when disposed by a player
            //maybe already fixed in ileft
            con.Dispose();

        }
    }
}
