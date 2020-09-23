using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamGame.LobbyVars
{
    public class LobbyModel
    {
        public string LobbyNumber { get; set; }
        public string Player1Health { get; set; }
        public List<string> Player1CursorLoc { get; set; }

    }
}
