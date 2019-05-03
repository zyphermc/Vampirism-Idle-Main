using System;
using UnityEngine;

namespace NumberShortening
{
    public class ShortenNumber
    {
        public string[] numberPostFix =
        {
            " Thousand",
            " Million",
            " Trillion"
        };

        public int postFixIndex; //index for post fix
        public bool decreased = false; //checks if index is already decreased

        public int shortenMethod = 0; //0 = post fix, 1 = scientific

        public string shortenNumber(double value, int method)
        {
            if(method == 0) //if post fix method
            {
                /* Post Fix Notation */
                int zeroAmount = (int)Math.Log10(value); //gets the amount of zeroes in value

                if (zeroAmount > 2) //if more than hundredths
                {
                    if (zeroAmount % 3 == 0) //if multiple of 3
                    {
                        postFixIndex = (int)(zeroAmount / 3f); //get the index by dividing the amount of zeroes by 3
                        decreased = false; //refresh boolean
                    }
                    else if (zeroAmount < (postFixIndex * 3) && decreased == false) //if value went below post fix (e.g. thousands, millions, etc.)
                    {
                        postFixIndex -= 1; //decrease the index by 1
                        decreased = true; //made true to prevent further decrease
                    }

                    return (value / Mathf.Pow(10, postFixIndex * 3)).ToString("F2") + numberPostFix[postFixIndex - 1]; //return value in two decimal places with a post fix
                }
                else
                {
                    return value.ToString(); //return value un-edited
                }
            }
            else if(method == 1) //if scientific method
            {
                /* Scientific Notation */
                return value.ToString("0.000e0"); //scientific notation
            }
            else //if neither, return it unedited
            {
                return value.ToString();
            }



        }
    }
}