using TeamGame.MinigameComps;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TeamGame.SqlAccess;
using TeamGame.SqlAccess.GameStateModels;
using Microsoft.AspNetCore.Components;
using TeamGame.PlayerHealthBar;
using System.Runtime.CompilerServices;
using System.Data;
using Microsoft.VisualBasic;

namespace TeamGame
{

    public class GameScript
    {

        //these vars are for updating your own game to be pulled by others
        public static string mycurrentgame;
        public static string p1currentgame;
        public static string p2currentgame;
        public static string p3currentgame;
        public static string p4currentgame = "sng";
        //array for variables this is gunna be a bitch in sql need to learn more about connected tables hehe
        public static string[,] p4gamevars = new string[3, 10]
        {
                {"sng","where 1st six is","where second six is","got first?","get second?","","","","","" }, //[00][01]
                {"mcn","first box","2nd box","3rd box","1st color","2nd color","3rd color","question color","question which spot","" }, //[10][11]
                {"ms","1st box rotation","2nd box rotation","3rd box rotation","4th box rotation","","","","","" }

        };
        //i will use the below to choose which game im playing locally
        public static string GetMyGame()
        {
            mycurrentgame = "sng";
            return "sng";
        }
        public static string GetGame()
        {
            if (GetMyGame() == "sng")
            {
                return "sixninegame";
            }
            return "idk";
        }
        //this will be used to get other players games and update your ui
        public static string GetPlayerGame(int a)
        {
            if (a == 1)
            {
                return p1currentgame;
            }
            if (a == 2)
            {
                return p2currentgame;
            }
            if (a == 3)
            {
                return p3currentgame;
            }
            if (a == 4)
            {
                return p4currentgame;
            }
            return "sorry you got an error bud";
        }

        public static int play1hp = 7;
        public static int play2hp = 7;
        public static int play3hp = 7;
        public static int play4hp = 11;

        public static string Coordinates { get; set; }
        public static double cursx { get; set; }
        public static double cursy { get; set; }

        public static void Player1MouseMoved(MouseEventArgs e)
        {
            cursx = e.ClientX;
            cursy = e.ClientY;
        }
    }


    public class TestClass
    {

        internal SixNineGame sng1;
        internal SixNineGame sng2;
        internal SixNineGame sng3;
        internal SixNineGame sng4;
        //internal can only be used by objects made from the class
        internal string getRealX()
        {
            if (this.GameVars is null)
            {
                return "0";
            }
            else
            {
                return (this.GameVars[0].Xcords) + "px";
            }
        }
        internal string getRealY()
        {
            if (this.GameVars is null)
            {
                return "0";
            }
            else
            {
                return (this.GameVars[0].Ycords) + "px";
            }
        }
        public Player1HealthBar p1hp;
        public Player2HealthBar p2hp;
        public Player3HealthBar p3hp;
        public Player4HealthBar p4hp;

        public static int play1hp = 11;
        public static int play2hp = 11;
        public static int play3hp = 11;
        public static int play4hp = 11;
        public GameVarsData _db;
        NavigationManager navManager;
        public void HealthMinus(int a)
        {
            if (a == 1)
            {
                TestClass.play1hp--;
            }
            if (a == 2)
            {
                TestClass.play2hp--;

            }
            if (a == 3)
            {
                TestClass.play3hp--;
            }
            if (a == 4)
            {
                TestClass.play4hp--;
            }
        }
        public void HealthPlus(int a)
        {
            if (a == 1)
            {
                TestClass.play1hp++;
            }
            if (a == 2)
            {
                TestClass.play2hp++;
            }
            if (a == 3)
            {
                TestClass.play3hp++;
            }
            if (a == 4)
            {
                TestClass.play4hp++;
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /// below is the sql stuff
        /// </summary>
        //create list of type personmodel named people
        //list is not instanciated right away
        public List<GameVarModel> GameVars;
        //instanciated right away with DisplaypersonMOdel() at end
    }

    //------game with all players together to count to twenty-----------

    public class TeamNumGame
    {
        public int totwenty = 0;
    }

    //------all the individual games below---------

    public class MakeASquare
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

    public class MemColorNum
    {
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

}

