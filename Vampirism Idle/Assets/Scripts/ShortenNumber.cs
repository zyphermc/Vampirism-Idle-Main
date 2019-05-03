using System;
using UnityEngine;

namespace NumberShortening
{
    public class ShortenNumber
    {
        public string[] numberSuffix =
        {
            " Thousand",
            " Million",
            " Trillion"
        };

        public int suffixIndex; //index for post fix
        public bool decreased = false; //checks if index is already decreased

        public int shortenMethod = 0; //0 = suffix, 1 = scientific

        public string shortenNumber(double value, int method)
        {
            if (method == 0) //if suffix method
            {
                /* Suffix Notation */
                int zeroAmount = (int)Math.Log10(value); //gets the amount of zeroes in value

                if (zeroAmount > 2) //if more than hundredths
                {
                    suffixIndex = (Mathf.FloorToInt(zeroAmount / 3f) * 3) / 3; //Calculate index to be the lowest multiple of three divided by three

                    return (value / Mathf.Pow(10, suffixIndex * 3)).ToString("F2") + numberSuffix[suffixIndex - 1]; //return value in two decimal places with a post fix
                }
                else
                {
                    return value.ToString(); //return value un-edited
                }
            }
            else if (method == 1) //if scientific notation method
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