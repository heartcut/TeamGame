using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class MyVarsSetter
    {
        //i take in my gamevarmodel that i update client side with my own vars and also take the lobbynum
        public static void SetSQL(DBGameVarModel dbgvm,int lobbynum,int playernum,GameVarModel gvm)
        {
            //ill use this to update the vars that i need
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            using var con = new SqlConnection(cs);
            con.Open();
            con.Query<DBGameVarModel>("UPDATE dbo.CursorPos SET P" + playernum + "Xcords =" + gvm.mycursx + ", P" + playernum +
                "Ycords = " + gvm.mycursy + " WHERE LobbyNumber =" + lobbynum + ";");


            con.Dispose();
            // use the connection here


        }
        //i take in my gamevarmodel that i update client side with my own vars and also take the lobbynum
        public static void SetGameVarSQL(int lobbynum, int playernum, int[] gamevars)
        {
            //ill use this to update the vars that i need
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            using var con = new SqlConnection(cs);
            con.Open();
            if (playernum != 0)
            {
                con.Query<DBGameVarModel>("UPDATE dbo.CursorPos SET P" + playernum + "Game =" + gamevars[0] + ", P" + playernum +
                                "GameVar1 = " + gamevars[1] + ", P" + playernum + "GameVar2 = " + gamevars[2] + " WHERE LobbyNumber =" + lobbynum + ";");
            }

            con.Dispose();
            // use the connection here


        }
    }
}
