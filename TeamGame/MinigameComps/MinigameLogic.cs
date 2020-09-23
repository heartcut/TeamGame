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
        public void randomSixes()
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
}
