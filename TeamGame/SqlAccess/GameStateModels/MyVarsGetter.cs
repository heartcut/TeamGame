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
            var cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\ServerSideBlazor\DataAccessLibrary\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            using var con = new SqlConnection(cs);
            con.Open();
            //new id 3 means making a new car object with the id = to 3??
            DBGameVarModel GVM = new DBGameVarModel();
            GVM = con.QueryFirst<DBGameVarModel>(@"SELECT * FROM CursorPos WHERE LobbyNumber=" + lobby);

            con.Dispose();

            return GVM;
        }

    }
}
