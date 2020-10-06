﻿using System;
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

            StopWatch();
            KeepRunning();

        }

        RenderFragment dynamicComponent(DBGameVarModel gvm , int a) => builder =>
        {

            if (a == 1)
            {
                //is player one
                if (gvm.P1Game == 1)
                {
                    //is the sixninegame
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
                else if (gvm.P1Game == 2)
                {
                    //render the other game
                    builder.OpenComponent(0, typeof(MakeSquare));
                    builder.CloseComponent();
                }
                else if (gvm.P1Game == 3)
                {
                    //render the other game
                    builder.OpenComponent(0, typeof(MemorizeColorNumber));
                    builder.CloseComponent();
                }
                else if (gvm.P1Game == null)
                {
                    //render the other game
                    builder.OpenComponent(0, typeof(SixNineGame));
                    builder.CloseComponent();
                }
            }

            if (a == 4)
            {
                //is player four
                if (gvm.P4Game == 1)
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
            
        };
        int choosegame = 1;
        void ChooseAGame(int a)
        {
            choosegame = a;
        }

        //oninitizlized async is called twice with server and component render
        //onafter is only called once afterwards so i used it to update the db and not get doubles
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            MyG.PlayerIAm = MyPlayerNum;
            MyG.MyLobby = MyLobbyNum;
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
                    MyG.MyCurrentGame = choosegame;
                    MyVarsSetter.SetSQL(MyDBVars,MyLobbyNum,MyPlayerNum,MyG);

                    
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
