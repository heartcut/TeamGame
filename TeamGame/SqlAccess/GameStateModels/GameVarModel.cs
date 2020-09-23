using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class GameVarModel
    { 
       

        public string MyGame { get; set; }
        public string OthersGame { get; set; }

        public string Xcords { get; set; }

        public string Ycords { get; set; }

        public string P1Health { get; set; }
        public string P2Health { get; set; }
        public string P3Health { get; set; }
        public string P4Health { get; set; }

        public string LobbyNumber { get; set; }

        public string PlayersInLobby { get; set; }

        public string P1Present { get; set; }
        public string P2Present { get; set; }
        public string P3Present { get; set; }
        public string P4Present { get; set; }


    }
}  
