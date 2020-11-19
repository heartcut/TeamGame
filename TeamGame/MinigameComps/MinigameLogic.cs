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
        //COLORS FOR THE FIRST PART TO MEMORIZE
        string firstcolor;
        string secondcolor;
        string thirdcolor;
        //number for the first part to memorize
        string firstnum;
        string secondnum;
        string thirdnum;
        string colorornumber;
        string positionofanswer;
        string fakeanswer1;
        string fakeanswer2;
        string numanswer;
        string colanswer;
        int answerspot;
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
            //second var
            firstnum = Var2.ToString().Substring(0, 1);
            secondnum = Var2.ToString().Substring(1, 1);
            thirdnum = Var2.ToString().Substring(2, 1);

            //thirdvar
            //1 is ask number-2 is ask color
            colorornumber = Var3.ToString().Substring(0, 1);
            numanswer = Var3.ToString().Substring(2, 1);
            
            switch (Var3.ToString().Substring(1, 1))
            {
                case "1": colanswer = "red"; break;
                case "2": colanswer = "blue"; break;
                case "3": colanswer = "yellow"; break;
                case "4": colanswer = "green"; break;
            }
            
            //fourth var
            positionofanswer = Var4.ToString().Substring(0, 1);
            if (colorornumber == "1")
            {
                //ask for number
                fakeanswer1 = Var4.ToString().Substring(1, 1);
                fakeanswer2 = Var4.ToString().Substring(2, 1);
                switch (positionofanswer)
                {
                    case "1": holderanswer1 = numanswer; holderanswer2 = fakeanswer1; holderanswer3 = fakeanswer2; break;
                    case "2": holderanswer1 = fakeanswer1; holderanswer2 = numanswer; holderanswer3 = fakeanswer2; break;
                    case "3": holderanswer1 = fakeanswer2; holderanswer2 = fakeanswer1; holderanswer3 = numanswer; break;
                }

            }
            else
            {
                //ask for color
                //1-red/2-blue/3-yellow/4-green
                switch (Var4.ToString().Substring(1, 1))
                {
                    case "1": fakeanswer1 = "red"; break;
                    case "2": fakeanswer1 = "blue"; break;
                    case "3": fakeanswer1 = "yellow"; break;
                    case "4": fakeanswer1 = "green"; break;
                }
                switch (Var4.ToString().Substring(2, 1))
                {
                    case "1": fakeanswer2 = "red"; break;
                    case "2": fakeanswer2 = "blue"; break;
                    case "3": fakeanswer2 = "yellow"; break;
                    case "4": fakeanswer2 = "green"; break;
                }
                switch (positionofanswer)
                {
                    case "1": holderanswer1 = colanswer; holderanswer2 = fakeanswer1; holderanswer3 = fakeanswer2; break;
                    case "2": holderanswer1 = fakeanswer1; holderanswer2 = colanswer; holderanswer3 = fakeanswer2; break;
                    case "3": holderanswer1 = fakeanswer2; holderanswer2 = fakeanswer1; holderanswer3 = colanswer; break;
                }
            }
            //todo need to add another variable form the generation so that the answer spots are in the same place for everyone
            
            ///todo finish this up and fix the checkanswer below
            //todo
            //get rid of the below
            MemorizeStopWatch();
        }

        public string holderanswer1;
        public string holderanswer2;
        public string holderanswer3;

        int memorizetimer = 5;
        bool is_stopwatchrunning = false;
        async Task MemorizeStopWatch()
        {
            is_stopwatchrunning = true;
            while (is_stopwatchrunning)
            {
                await Task.Delay(1000);
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
        public void CheckAnswer(int onecolortwonumber,string answer)
        {
            if (onecolortwonumber == 1)
            {
                if (answer == colanswer)
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
            else
            {
                if (answer == numanswer)
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
    }

    public partial class MakeSquare
    {
        string uprot;
        string downrot;
        string leftrot;
        string rightrot;
        //todo fix this
        protected override async Task OnInitializedAsync()
        {
            
            switch (Var1)
            {
                case "1": uprot = "rotateninty"; break;
                case "2": uprot = "rotateoneeighty"; break;
                case "3": uprot = "rotatetwoseventy"; break;
            }
            switch (Var2)
            {
                case "1": downrot = "rotateninty"; break;
                case "2": downrot = "rotateoneeighty"; break;
                case "3": downrot = "rotatetwoseventy"; break;
            }
            switch (Var3)
            {
                case "1": leftrot = "rotateninty"; break;
                case "2": leftrot = "rotateoneeighty"; break;
                case "3": leftrot = "rotatetwoseventy"; break;
            }
            switch (Var4)
            {
                case "1": rightrot = "rotateninty"; break;
                case "2": rightrot = "rotateoneeighty"; break;
                case "3": rightrot = "rotatetwoseventy"; break;
            }
        }


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
