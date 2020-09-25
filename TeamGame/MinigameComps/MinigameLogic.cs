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
            RandomSixes();
        }
        int numof6 = 0;
        public string[,] sna = new string[4, 8]
            {
            {"9","9","9","9","9","9","9","9"},
            {"9","9","9","9","9","9","9","9"},
            {"9","9","9","9","9","9","9","9"},
            {"9","9","9","9","9","9","9","9"}
            };
        public string status;
        public int firstrow;
        public int secondrow;
        public int firstcol;
        public int secondcol;
        public int rightanswer = 0;
        public int wronganswer = 0;
        public void IsSix(int a, int b)
        {
            if ((a == firstrow && b == firstcol) || (a == secondrow && b == secondcol))
            {
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
        public void RandomSixes()
        {
            Random rnd = new Random();
            if (numof6 < 2)
            {
                firstrow = rnd.Next(3);
                secondrow = rnd.Next(3);
                firstcol = rnd.Next(7);
                secondcol = rnd.Next(7);
                sna[firstrow, firstcol] = "6";
                sna[secondrow, secondcol] = "6";
                numof6 = 2;
            }
        }
    }

    public partial class MemorizeColorNumber
    {

        //this is the onload overridded method
        //you can do some kind of wait stuff idk but it works for now
        protected override async Task OnInitializedAsync()
        {
            PickColorNums();
            await MemorizeStopWatch();
            PickQ();
            PickAnswers();
        }

        int memorizetimer = 2;
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
        Random rndm = new Random();
        //below is picking that question to ask either color or number
        public bool ranbefore = false;
        public string con;
        public void PickQ()
        {
            if (!ranbefore)
            {
                if (rndm.Next(1, 3) == 1)
                {
                    con = "color";
                    ranbefore = true;
                }
                else
                {
                    con = "number";
                    ranbefore = true;
                }
            }
        }
        //picking thw answer optoins
        public string mcnanswer;
        public string whichbox;
        public string answer1;
        public string answer2;
        public string answer3;
        public int whichisanswer;
        public void PickAnswers()
        {
            if (con == "color")
            {
                //answer is a number
                int whichcolor = rndm.Next(1, 4);
                if (whichcolor == 1)
                {
                    mcnanswer = firstcolor;
                    whichbox = "first";
                }
                else if (whichcolor == 2)
                {
                    mcnanswer = secondcolor;
                    whichbox = "second";
                }
                else
                {
                    //whichcolor is 3
                    mcnanswer = thirdcolor;
                    whichbox = "third";

                }
            }
            //i know its speghetti which all the if else but suck it
            else
            {
                //answer is a number
                int whichnumber = rndm.Next(1, 4);
                if (whichnumber == 1)
                {
                    mcnanswer = firstnumber.ToString();
                    whichbox = "first";
                }
                else if (whichnumber == 2)
                {
                    mcnanswer = secondnumber.ToString();
                    whichbox = "second";
                }
                else
                {
                    //whichnumber is 3
                    mcnanswer = thirdnumber.ToString();
                    whichbox = "third";
                }
            }
            //below i will populate variables to put in the button answers
            //yea i know this is spaghetti too
            whichisanswer = rndm.Next(1, 4);
            if (whichisanswer == 1)
            {
                answer1 = mcnanswer;
            }
            else
            {
                if (con == "color")
                {
                    answer1 = colors[rndm.Next(0, 4)];
                    while (answer1 == mcnanswer)
                    {
                        answer1 = colors[rndm.Next(0, 4)];
                    }
                }
                else
                {
                    //is number
                    answer1 = rndm.Next(0, 9).ToString();
                    while (answer1 == mcnanswer.ToString())
                    {
                        answer1 = rndm.Next(0, 9).ToString();
                    }
                }
            }
            if (whichisanswer == 2)
            {
                answer2 = mcnanswer;
            }
            else
            {
                if (con == "color")
                {
                    answer2 = colors[rndm.Next(0, 4)];
                    while (answer2 == answer1)
                    {
                        answer2 = colors[rndm.Next(0, 4)];
                    }
                }
                else
                {
                    //is number
                    answer2 = rndm.Next(0, 9).ToString();
                    while (answer2 == answer1.ToString())
                    {
                        answer2 = rndm.Next(0, 9).ToString();
                    }
                }
            }
            if (whichisanswer == 3)
            {
                answer3 = mcnanswer;
            }
            else
            {
                if (con == "color")
                {
                    answer3 = colors[rndm.Next(0, 4)];
                    while (answer3 == answer1 || answer3 == answer2)
                    {
                        answer3 = colors[rndm.Next(0, 4)];
                    }
                }
                else
                {
                    //is number
                    answer3 = rndm.Next(0, 9).ToString();
                    while (answer3 == answer1.ToString() || answer3 == answer2)
                    {
                        answer3 = rndm.Next(0, 9).ToString();
                    }
                }
            }
        }
        //picking the random colors and numbers
        public bool picked = false;
        public string firstcolor = "blue";
        public string secondcolor = "blue";
        public string thirdcolor = "blue";
        public int firstnumber = 1;
        public int secondnumber = 2;
        public int thirdnumber = 3;
        string[] colors = new string[4] { "blue", "red", "green", "yellow" };
        public void PickColorNums()
        {
            if (!picked)
            {
                //gunna do some if else fuckery to get different for each which is what i did above for thw answers
                firstcolor = colors[rndm.Next(0, 4)];
                secondcolor = colors[rndm.Next(0, 4)];
                if (secondcolor == firstcolor)
                {
                    while (secondcolor == firstcolor)
                    {
                        secondcolor = colors[rndm.Next(0, 4)];
                    }
                }
                thirdcolor = colors[rndm.Next(0, 4)];
                if (thirdcolor == firstcolor || thirdcolor == secondcolor)
                {
                    while (thirdcolor == firstcolor || thirdcolor == secondcolor)
                    {
                        thirdcolor = colors[rndm.Next(0, 4)];
                    }
                }
                firstnumber = rndm.Next(0, 9);
                secondnumber = rndm.Next(0, 9);
                if (secondnumber == firstnumber)
                {
                    while (secondnumber == firstnumber)
                    {
                        secondnumber = rndm.Next(0, 9);
                    }
                }
                thirdnumber = rndm.Next(0, 9);
                if (thirdnumber == firstnumber || thirdnumber == secondnumber)
                {
                    while (thirdnumber == firstnumber || thirdnumber == secondnumber)
                    {
                        thirdnumber = rndm.Next(0, 9);
                    }
                }
                picked = true;
            }
        }
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
