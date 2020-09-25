using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamGame.MinigameComps;
using TeamGame.PlayerHealthBar;

namespace TeamGame.SqlAccess.GameStateModels
{
    public class GameVarModel
    {

        private int MyLobbyNumber;
        private int MyPlayerNumber;
        internal MyVarsGetter MyGame;
        //empty constructor shouldn't be here but i need to fix the SQL FIRSTTT!!@#!@#!@#!@#
        public GameVarModel()
        {
            //test
        }
        public GameVarModel(int LobbyNumber, int playernumber)
        {
            MyLobbyNumber = LobbyNumber;
            MyPlayerNumber = playernumber;
            MyGame = new MyVarsGetter(LobbyNumber, playernumber);
        }
        //these should be temp
        internal SixNineGame sng1 = new SixNineGame();
        internal SixNineGame sng2 = new SixNineGame();
        internal SixNineGame sng3 = new SixNineGame();
        internal SixNineGame sng4 = new SixNineGame();
        //please be temp
        public Player1HealthBar p1hp;
        public Player2HealthBar p2hp;
        public Player3HealthBar p3hp;
        public Player4HealthBar p4hp;

        public int play1hp = 11;
        public int play2hp = 11;
        public int play3hp = 11;
        public int play4hp = 11;

        

        //below are all db vars
        public string P1Game { get; set; }
        public string P2Game { get; set; }
        public string P3Game { get; set; }
        public string P4Game { get; set; }

        public double P1Xcords { get; set; }
        public double P1Ycords { get; set; }
        public double P2Xcords { get; set; }
        public double P2Ycords { get; set; }
        public double P3Xcords { get; set; }
        public double P3Ycords { get; set; }
        public double P4Xcords { get; set; }
        public double P4Ycords { get; set; }

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
