using TeamGame.SqlAccess.GameStateModels;
using TeamGame.SqlAccess;
using TeamGame;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeamGame.SqlAccess
{
    public class GameVarsData
    {
        private readonly SqlDataAccess _db;

        public GameVarsData(SqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<GameVarModel>> GetVars()
        {
            //grabs all form the table
            string sql = "select * from dbo.CursorPos where LobbyNumber = 0";

            return _db.LoadData<GameVarModel, dynamic>(sql, new { });

        }
        //this is where we add to the db
        public Task PutVars(GameVarModel lobby)
        {
            string sql = @"UPDATE dbo.CursorPos
                            SET Xcords=@Xcords,Ycords=@Ycords,P1Health=@P1Health,P2Health=@P2Health,P3Health=@P3Health,P4Health=@P4Health
                            WHERE LobbyNumber = 0;";

            //the two parameters sql and person
            //sql is the command we are doing on the db and the perosn is the stuff we are passing into 
            //with the command in this case a person object table thing with the command to add
            return _db.SaveData(sql, lobby);
        }
        public Task<List<GameVarModel>> GetAmountOfPlayers()
        {
            //grabs all form the table
            string sql = "select PlayersInLobby from dbo.CursorPos where Id = 1";

            return _db.LoadData<GameVarModel, dynamic>(sql, new { });

        }
        public Task ChangeAmountOfPlayers(GameVarModel lobby,string a)
        {
            string sql = @"UPDATE dbo.CursorPos SET P"+ a + "Present = 1 WHERE LobbyNumber = 0;";
            
            return _db.SaveData(sql, lobby);
        }
    }
}
