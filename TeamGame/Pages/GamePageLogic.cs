using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// for the js
using TeamGame.JavaScript;
using TeamGame;
using TeamGame.SqlAccess;
using TeamGame.SqlAccess.GameStateModels;
using TeamGame.PlayerHealthBar;
using Microsoft.AspNetCore.Components;
using TeamGame.MinigameComps;


namespace TeamGame.Pages
{
    public partial class GamePage
    {
        //parameters i get in from the gamepagecontainer
        //maybe they cant be static?
        [Parameter]
        public int MyLobbyNum { get; set; }
        [Parameter]
        public int MyPlayerNum { get; set; }

        //for the js
        [Inject]
        protected BrowserService Service { get; set; }

        //all of these are instead of doing the at inject
        [Inject]
        protected GameVarsData _db { get; set; }
        [Inject]
        protected NavigationManager navManager{ get; set; }

        GameVarModel MyG;
        protected override async Task OnInitializedAsync()
        {
            MyG = MyVarsGetter.GetSQL(MyLobbyNum);

            StopWatch();
            KeepRunning();

        }

        RenderFragment dynamicComponent(GameVarModel gvm , int a) => builder =>
        {
            if (a == 4)
            {
                //is player four
                if (gvm.P4Game == "sng")
                {
                    //is the sixninegame
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
                else if (gvm.P4Game == null)
                {
                    //render the other game
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
            }
            if (a == 1)
            {
                //is player one
                if (gvm.P1Game == "sng")
                {
                    //is the sixninegame
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
                else if (gvm.P1Game == null)
                {
                    //render the other game
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
            }
        };
        int choosegame = 1;
        void ChooseAGame(int a)
        {
            choosegame = a;
        }

        //oninitizlized async is called twice with server and component render
        //onafter is only called once afterwards so i used it to update the db and not get doubles
        //uncomment for lobby
        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        GetPlayerAmountInLobby();
        //    }
        //}

        bool is_rendered = false;
        async Task KeepRunning()
        {
            is_rendered = true;
            while (is_rendered)
            {
                //Task.Delay(1000);
                if (is_rendered)
                {
                    //js the three below
                    var dimension = await Service.GetDimensions();
                    MyG.Height = dimension.Height;
                    MyG.Width = dimension.Width;

                    //need to put the setting and getting vars here to update constantly
                    //could also put the mouse stuff in whatever i call to update
                    StateHasChanged();
                }
            }
        }

        TimeSpan stopwatchvalue = new TimeSpan();
        bool is_stopwatchrunning = false;
        async Task StopWatch()
        {
            is_stopwatchrunning = true;
            while (is_stopwatchrunning)
            {
                await Task.Delay(1000);
                if (is_stopwatchrunning)
                {
                    stopwatchvalue = stopwatchvalue.Add(new TimeSpan(0, 0, 1));
                    StateHasChanged();
                }
            }
        }
        //uncomment to get the lobby players stuff working
        //public string WhatPlayerAmI;
        //public string HowManyPlayersInLobby;
        //public void GetPlayerAmountInLobby()
        //{
        //    bool pickedmyplayerspot = false;
        //    if (tc.GameVars[0].P1Present == "0")
        //    {
        //        WhatPlayerAmI = "1";
        //        HowManyPlayersInLobby = "1";
        //        pickedmyplayerspot = true;
        //        GameVarModel temp = new GameVarModel();
        //        temp.P1Present = "1";
        //        _db.ChangeAmountOfPlayers(temp, "1");
        //    }
        //    else if (tc.GameVars[0].P2Present == "0" && !pickedmyplayerspot)
        //    {
        //        WhatPlayerAmI = "2";
        //        HowManyPlayersInLobby = "2";
        //        pickedmyplayerspot = true;
        //        GameVarModel temp = new GameVarModel();
        //        temp.P2Present = "1";
        //        _db.ChangeAmountOfPlayers(temp, "2");
        //    }
        //    else if (tc.GameVars[0].P3Present == "0" && !pickedmyplayerspot)
        //    {
        //        WhatPlayerAmI = "3";
        //        HowManyPlayersInLobby = "3";
        //        pickedmyplayerspot = true;
        //        GameVarModel temp = new GameVarModel();
        //        temp.P3Present = "1";
        //        _db.ChangeAmountOfPlayers(temp, "3");
        //    }
        //    else if (tc.GameVars[0].P4Present == "0" && !pickedmyplayerspot)
        //    {
        //        WhatPlayerAmI = "4";
        //        HowManyPlayersInLobby = "4";
        //        pickedmyplayerspot = true;
        //        GameVarModel temp = new GameVarModel();
        //        temp.P4Present = "1";
        //        _db.ChangeAmountOfPlayers(temp, "4");
        //    }
        //    else if (!pickedmyplayerspot)
        //    {
        //        navManager.NavigateTo("/lobbyfull");
        //    }
        //}
        
        public void Dispose()
        {
            DBConnection.ILeft(MyLobbyNum);
        }

    }
}
