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
using TeamGame.GamePageComps;
using TeamGame.Pages;
using TeamGame.Shared;
using System.Reflection.Metadata;

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
        protected NavigationManager navManager{ get; set; }

        GameVarModel MyG = new GameVarModel();
        DBGameVarModel MyDBVars;
        protected override async Task OnInitializedAsync()
        {

            MyDBVars = MyVarsGetter.GetSQL(MyLobbyNum);
            MyG.MyGameVars = GameScript.GetPlayerGameAndVars();
            StopWatch();
            KeepRunning();

        }
        //oninitizlized async is called twice with server and component render
        //onafter is only called once afterwards so i used it to update the db and not get doubles
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            MyG.PlayerIAm = MyPlayerNum;
            MyG.MyLobby = MyLobbyNum;
            StartLoadScreen();
        }

        bool loadingdone = false;
        private async Task StartLoadScreen()
        {
            //change this to wait longer
            await Task.Delay(5);
            loadingdone = true;
        }

        bool is_rendered = false;
        
        async Task KeepRunning()
        {
            is_rendered = true;
            while (is_rendered)
            {
                //Task.Delay(1);
                if (is_rendered)
                {
                    //js the three below
                    var dimension = await Service.GetDimensions();
                    MyG.Height = dimension.Height;
                    MyG.Width = dimension.Width;
                    MyDBVars = MyVarsGetter.GetSQL(MyLobbyNum);
                    

                    MyVarsSetter.SetSQL(MyDBVars,MyLobbyNum,MyPlayerNum,MyG);
                    
                    MyVarsSetter.SetGameVarSQL(MyLobbyNum, MyPlayerNum, MyG.MyGameVars);

                    
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
        
        
        public void Dispose()
        {
            DBConnection.ILeft(MyLobbyNum);
        }

    }
}
