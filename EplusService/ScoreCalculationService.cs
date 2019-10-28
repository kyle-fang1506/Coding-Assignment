using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EplusService
{
    public class ScoreCalculationService: ICalculationService
    {
        public char?[] Input { get; set; }
     


        //the API method calculate the score is exposed to public
        public int ScoreCalculate()
        {
            
            char?[] cleanIgnoredArray = CleanIgnored(this.Input);

            cleanIgnoredArray = CleanGarbage(cleanIgnoredArray);

            return CalculateScore(cleanIgnoredArray);
            
        }

        //this function cleans the futile attempt i.e !
        private char?[] CleanIgnored(char?[] input)
        {
            int length = input.Length;
            int i = 0;
            while (i < length)
            {
                if (input[i] == '!')
                {
                    input[i] = null;
                    i++;
                    if (i < length)
                    {
                        input[i] = null;
                    }
                }
                i++;
            }

            return input;
        }


        //this function is used to clear the garbage
        private char?[] CleanGarbage(char?[] input)
        {
            int length = input.Length;
            int i = 0; //garbige begin pointer
            int j = 0;//garbige end pointer
            //int k = 0;//

            while (i < length)
            {
                if (input[i] == '<')
                {
                    j = i;
                    //k = i;
                    while (j < length)
                    {

                        if (j < length && input[j] == '>')
                        {
                            //do clean
                            for (; i <= j; i++)
                            {
                                input[i] = null;
                            }
                            //i++;
                            //j++;
                            //i = k;//now i==j==k and point to a new char;
                            break;//jump out of the inner while loop;



                        }
                        else if (j < length)
                        {
                            j++;
                        }
                        else
                        {
                            return input;
                        }

                    }

                }
                i++;

            }
            return input;


        }


        //the CalculateScore calculates the total score using Stack data structure
        //also check if the input is a valid single large group, otherwise will return -1
        private int CalculateScore(char?[] input)
        {
            //with the filter of previous methods, the '{' and '}' are the only valid char
            //that affect the total score
            //I will create a stack which only add the '{' and
            int totalScore = 0;
            int depth = 0; //this will works on caluating the score of a single "{}" pair
            Stack<char> stack = new Stack<char>();
            int length = input.Length;

            if (length == 0) return 0;
            //a valid input must start with '{' and end with'}'
            if (input[0] != '{' || input[length-1] != '}') return -1;

            for (int i = 0; i < length; i++)
            {

                char? character = input[i];
                if (character == '{')
                {
                    stack.Push('{');
                    depth++;
                }
                else if (character == '}')
                {
                    totalScore += depth;
                    depth--;
                    //check if the input is a single large group an no extra '}'
                    if (depth == 0 && i < length - 1) return -1; //-1 stand for invalid inpupt
                    stack.Pop();

                }
            }

            //if stack is not empty, there must be extra '{', resulting a invaid input
            if (stack.Count != 0) return -1;

            return totalScore;

        }

    }
}