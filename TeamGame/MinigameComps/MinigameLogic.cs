using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamGame.MinigameComps
{
    public class MinigameLogic
    {
    }
    //this is how to put code for component in a regular class file
    public partial class SixNineGame
    {
        
        //this is the onload overridded method
        //you can do some kind of wait stuff idk but it works for now
        protected override void OnInitialized()
        {
            //takes the position of the variable from the db and makes it a 6
            sna[Var1] = "6";
            sna[Var2] = "6";
        }
        public string[] sna = new string[32]
        {
            "9","9","9","9","9","9","9","9",
            "9","9","9","9","9","9","9","9",
            "9","9","9","9","9","9","9","9",
            "9","9","9","9","9","9","9","9"
        };
        public string status;
        public int rightanswer = 0;
        public int wronganswer = 0;
        public void IsSix(int a)
        {
            if (sna[a] == "6")
            {
                sna[a] = "9";
                if (rightanswer == 1)
                {
                    status = "youwin!";
                }
                rightanswer++;
            }
            else if (wronganswer >= 2)
            {
                status = "youlose";
            }
            else
            {
                wronganswer++;
                status = wronganswer + " wronganswer" + rightanswer + " right answer";
            }
        }
    }

    public partial class MemorizeColorNumber
    {

        //this is the onload overridded method
        //you can do some kind of wait stuff idk but it works for now
        string firstcolor;
        string secondcolor;
        string thirdcolor;
        protected override async Task OnInitializedAsync()
        {
            //below sets the var from the db to something useable within the code
            //in this case its setting the first answer colors
            //return in the form of [color-color-color,num-num-num,whetherqiscolorornum-colans-numans,posofanswer-fakeanswer-fakeanswer]
            switch (Var1.ToString().Substring(0, 1))
            {
                case "1": firstcolor = "red"; break;
                case "2": firstcolor = "blue"; break;
                case "3": firstcolor = "yellow"; break;
                case "4": firstcolor = "green"; break;
            }
            switch (Var1.ToString().Substring(1, 1))
            {
                case "1": secondcolor = "red"; break;
                case "2": secondcolor = "blue"; break;
                case "3": secondcolor = "yellow"; break;
                case "4": secondcolor = "green"; break;
            }
            switch (Var1.ToString().Substring(2, 1))
            {
                case "1": thirdcolor = "red"; break;
                case "2": thirdcolor = "blue"; break;
                case "3": thirdcolor = "yellow"; break;
                case "4": thirdcolor = "green"; break;
            }
            ///todo finish this up and fix the checkanswer below
            //todo
            //get rid of the below
            MemorizeStopWatch();
        }

        int memorizetimer = 2;
        bool is_stopwatchrunning = false;
        async Task MemorizeStopWatch()
        {
            is_stopwatchrunning = true;
            while (is_stopwatchrunning)
            {
                await Task.Delay(5000);
                if (is_stopwatchrunning)
                {
                    memorizetimer = memorizetimer - 1;
                    StateHasChanged();
                }
            }
        }

        //1 is game state 2 is correct 3 is wrong
        public int MCNGameState = 1;
        //picking thw answer optoins
        public string mcnanswer;
        public string whichbox;
        public string answer1;
        public string answer2;
        public string answer3;
        public int whichisanswer;
        public void CheckAnswer(int a)
        {
            if (a == whichisanswer)
            {
                //correct screen
                MCNGameState = 2;
            }
            else
            {
                //incorrect screen
                MCNGameState = 3;
            }
        }
    }

    public partial class MakeSquare
    {
        public string uprot = "rotatezero";
        public string downrot = "rotatezero";
        public string leftrot = "rotatezero";
        public string rightrot = "rotatezero";
        public string NextPosition(string a)
        {
            if (a == "rotatezero")
            {
                return "rotateninty";
            }
            else if (a == "rotateninty")
            {
                return "rotateoneeighty";
            }
            else if (a == "rotateoneeighty")
            {
                return "rotatetwoseventy";
            }
            else if (a == "rotatetwoseventy")
            {
                return "rotatezero";
            }
            return "rotateoneeighty";
        }
        public void SquareRotate(int a)
        {
            if (a == 0)
            {
                uprot = NextPosition(uprot);
            }
            if (a == 1)
            {
                downrot = NextPosition(downrot);
            }
            if (a == 2)
            {
                leftrot = NextPosition(leftrot);
            }
            if (a == 3)
            {
                rightrot = NextPosition(rightrot);
            }
        }

    }
}
