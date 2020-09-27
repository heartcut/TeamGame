using Dapper;
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
        public static bool CheckLobby(int lobnumber)
        {
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);
            con.Open();
            //new id 3 means making a new car object with the id = to 3??
            int players = con.QueryFirst<int>(@"SELECT PlayersInLobby FROM CursorPos WHERE LobbyNumber=" + lobnumber);
            bool canjoin;
            if (players < 4)
            {
                canjoin = true;
            }
            else
            {
                canjoin = false;
            }
            con.Dispose();

            return canjoin;
        }
        public static void ILeft(int lobnumber)
        {
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);
            con.Open();
            //new id 3 means making a new car object with the id = to 3??
            int players = con.QueryFirst<int>(@"SELECT PlayersInLobby FROM CursorPos WHERE LobbyNumber=" + lobnumber);
            players--;
            con.ExecuteAsync("UPDATE CursorPos SET PlayersInLobby ="+players+" WHERE LobbyNumber = " + lobnumber + "; ");
            
            con.Dispose();

        }
    }
}
