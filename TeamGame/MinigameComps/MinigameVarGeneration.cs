using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamGame.MinigameComps
{
    public class MinigameVarGeneration
    {
        //this will take in what game it is and return an array of the proper variables for the game
        //will return in the form [var1,var2,var3,var4] depending on the game
        public static int[] GenerateVariables(int whatgame)
        {
            Random rndm = new Random();
            if (whatgame == 1)
            {
                //make a squre
                //returns one int 1111-4444 each digit representing rotation state of each quarter of the sqaure
                int[] temp = new int[4];
                for(int i = 0; i < 4; i++)
                {
                    temp[i] = rndm.Next(1, 5);
                }
                return temp;
            }
            ///todo 
            else if (whatgame == 2)
            {
                //memcolornum
                //generates the colors and numbers for the spots
                //and also needs to generate what the fake answers will be along with whether to ask number or color
                //return in the form of [colorcolorcolor,numnumnum,whetherqiscolorornum,answerslikecolorcolrcolr or numnumum]
                //yikes i know
            }
            else
            {
                //sixninegame
                //just needs to generate 2 random numbers between 0-31 which will be where the 6s are
                int[] temp = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    temp[i] = rndm.Next(0, 32);
                }
                return temp;
            }

            return null;
        }



    }
}
