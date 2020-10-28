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
            ///todo i will need to store the answer i think
            else if (whatgame == 2)
            {
                //memcolornum
                //generates the colors and numbers for the spots
                //and also needs to generate what the fake answers will be along with whether to ask number or color
                //return in the form of [color-color-color,num-num-num,whetherqiscolorornum-colans-numans,posofanswer-fakeanswer-fakeanswer]
                //yikes i know
                int[] temp = new int[4];
                //1-red/2-blue/3-yellow/4-green
                //this selects a random 3 numbers ill translate into colors later
                //and puts into first var spot
                var list = new List<int> { 123, 234, 341, 412 };
                temp[0] = list[rndm.Next(list.Count)];
                //below gets the 3 numbers 0-9 and puts them together by multiplying
                //so they are in one variable in the 2nd spot
                int[] temp1 = new int[3];
                temp1[0] = rndm.Next(0, 10);
                do
                {
                    temp1[1] = rndm.Next(0, 10);
                } while (temp1[1] == temp1[0]);
                do
                {
                    temp1[2] = rndm.Next(0, 10);
                } while (temp1[2] == temp1[0]|| temp1[2] == temp1[1]);
                temp[1] = ((temp1[0] * 100) + (temp1[1] * 10) + temp1[2]);
                //below i choose whether im going to ask for the number or color
                //and also randomly choose the answer with the color and number
                //1 is ask number-2 is ask color
                int asknumorcolor = rndm.Next(1, 3);
                int holder = rndm.Next(0, 3);
                //hopefully this works yeah right
                string coloranswer1 = temp[0].ToString();
                int coloranswer2 = Int32.Parse(coloranswer1.Substring(holder, 1));
                string numanswer1 = temp[1].ToString();
                int numanswer2 = Int32.Parse(numanswer1.Substring(holder, 1));
                //first digit is whether to ask color or number
                //second is the color of the answer
                //third digit is the number of the answer
                temp[2] = ((asknumorcolor * 100) + (coloranswer2 * 10) + numanswer2);
                //last thing is i need to generate what random wrong answers
                //after figuring what im going to ask for
                int whereansweris = rndm.Next(1, 4);
                //returns in the form of
                //first digit position of answer
                //last two digits wrong answers
                if (asknumorcolor == 1)
                {
                    //ask for number of box supplying color
                    int fakeanswer1;
                    int fakeanswer2;
                    do
                    {
                        fakeanswer1 = rndm.Next(0, 10);
                        fakeanswer2 = rndm.Next(0, 10);
                    } while(fakeanswer1==numanswer2||fakeanswer2==numanswer2);
                    temp[3] = ((whereansweris * 100) + (fakeanswer1 * 10) + fakeanswer2);
                }
                else
                {
                    //ask for color of box supplying number
                    int fakeanswer1;
                    int fakeanswer2;
                    do
                    {
                        fakeanswer1 = rndm.Next(1, 5);
                        fakeanswer2 = rndm.Next(1, 5);
                    } while (fakeanswer1 == coloranswer2 || fakeanswer2 == coloranswer2);
                    temp[3] = ((whereansweris * 100) + (fakeanswer1 * 10) + fakeanswer2);
                }
                return temp;
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
        }
    }
}
