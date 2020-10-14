using Dapper;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using TeamGame.Pages;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class MyVarsGetter
    {   
        
        public static DBGameVarModel GetSQL(int lobby)
        {

            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);

            con.Open();


            DBGameVarModel GVM = con.QueryFirst<DBGameVarModel>(@"SELECT * FROM CursorPos WHERE LobbyNumber=" + lobby + ";");
            // Create the command
            // Add the parameters.
            con.Dispose();
            return GVM;
            // use the connection here
        }
        public static int[] GetGameSQL(int lobby,int player)
        {

            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);

            con.Open();


            DBGameVarModel GVM = con.QueryFirst<DBGameVarModel>(@"SELECT * FROM CursorPos WHERE LobbyNumber=" + lobby + ";");
            // Create the command
            // Add the parameters.
            int[] gamevars = new int[3];
            if (player == 1)
            {
                gamevars = new int[] { GVM.P1Game, GVM.P1GameVar1, GVM.P1GameVar2 };

            }
            else if (player == 2)
            {
                gamevars = new int[] { GVM.P2Game, GVM.P2GameVar1, GVM.P2GameVar2 };

            }
            else if (player == 3)
            {
                gamevars = new int[] { GVM.P3Game, GVM.P3GameVar1, GVM.P3GameVar2 };

            }
            else
            {
                gamevars = new int[] { GVM.P4Game, GVM.P4GameVar1, GVM.P4GameVar2 };

            }
            con.Dispose();
            return gamevars;
            // use the connection here
        }

    }
}
