using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class MyVarsSetter
    {
        //i take in my gamevarmodel that i update client side with my own vars and also take the lobbynum
        public static void SetSQL(GameVarModel gvm,int lobbynum,int playeriam)
        {
            //ill use this to update the vars that i need
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);
            con.Open();
            con.ExecuteAsync("UPDATE CursorPos SET P"+playeriam+"Xcords = "+gvm.mycursx+
                "P"+playeriam+"Ycords = "+gvm.mycursy+
                "P"+playeriam+"Game = "+gvm.MyCurrentGame+
                " WHERE LobbyNumber = " + lobbynum + "; ");

            con.Dispose();
        }
    }
}
