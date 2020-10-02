using Dapper;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TeamGame.Pages;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class MyVarsGetter
    {   
        
        public static DBGameVarModel GetSQL(int lobby)
        {



            SqlConnection conn = new SqlConnection();
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);

            con.Open();

            DBGameVarModel GVM = new DBGameVarModel();

            GVM = con.QueryFirst<DBGameVarModel>(@"SELECT * FROM CursorPos WHERE LobbyNumber=" + lobby + ";");
            // Create the command
            // Add the parameters.
            return GVM;
            // use the connection here
        }

    }
}
