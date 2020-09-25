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


        TestClass tc = new TestClass();
        
        RenderFragment dynamicComponent(int a) => builder =>
        {
            if (a == 4)
            {
                //is player four
                if (GameScript.p4currentgame == "sng")
                {
                    //is the sixninegame
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
                else if (GameScript.p4currentgame == "another game")
                {
                    //render the other game
                }

            }
            if (a == 1)
            {
                //is player one
                if (GameScript.p1currentgame == "sng")
                {
                    //is the sixninegame
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
                else if (GameScript.p1currentgame == "another game")
                {
                    //render the other game
                }

            }

        };
        int choosegame = 1;
        void ChooseAGame(int a)
        {
            choosegame = a;
        }
        GameVarModel MyG;
        protected override async Task OnInitializedAsync()
        {
            //im putting this here because of the static initializer stuff
            MyG = new GameVarModel(MyLobbyNum, MyPlayerNum);

            //below goes with sql
            MyG.MyGame.GameVars = await _db.GetVars();
            //GetPlayerAmountInLobby();
            //lmao
            StopWatch();
            KeepRunning();

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

        //js testing
        //vars i get from the broswerservice
        //TeamGame.JavaScript.BrowserService
        public static int Height { get; set; }
        public static int Width { get; set; }

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
                    Height = dimension.Height;
                    MyG.MyGame.Height = dimension.Height;
                    MyG.MyGame.Width = dimension.Width;
                    Width = dimension.Width;

                    MyG.MyGame.GameVars = await _db.GetVars();
                    await InsertVars();
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
        private async Task InsertVars()
        {
            //converting models types manually
            MyG.P1Xcords = GameScript.cursx;
            MyG.P1Ycords = GameScript.cursy;
            //p.Xcords = newGameVar.Xcords;
            //p.Ycords = newGameVar.Ycords;
            MyG.P1Health = GameScript.play1hp.ToString();
            MyG.P2Health = GameScript.play2hp.ToString();

            MyG.P3Health = GameScript.play3hp.ToString();
            MyG.P4Health = GameScript.play4hp.ToString();
            //returns the mycurrentgame var because thats all i need to give to the db
            MyG.P3Game = GameScript.mycurrentgame;
            //actually putting in here
            await _db.PutVars(MyG);
            //below is adding the person to the table
            //but not from the db from the new created person object p that we put in
            //below is cleaing the slate of the inserted person and the values
            //newGameVar = new DisplayGameVarsModel();
        }


    }
}
