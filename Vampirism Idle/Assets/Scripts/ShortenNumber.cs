using System;
using UnityEngine;

namespace NumberShortening
{
    public class ShortenNumber
    {
        public string[] numberSuffix = //contains the suffixes
        {
            " K",
            " M",
            " T",
            " q",
            " Q"
        };

        public int suffixIndex; //index for suffix
        public bool decreased = false; //checks if index is already decreased

        public int shortenMethod = 0; //0 = suffix, 1 = scientific

        public string shortenNumber(double value, int method, int decimalPlaces)
        {
            if (method == 0) //if suffix method
            {
                /* Suffix Notation */
                int zeroAmount = (int)Math.Log10(value); //gets the amount of zeroes in value

                if (zeroAmount > 2) //if more than hundredths
                {
                    suffixIndex = (Mathf.FloorToInt(zeroAmount / 3f) * 3) / 3; //Calculate index to be the lowest multiple of three divided by three

                    return (/*Math.Floor*/(value / Mathf.Pow(10, suffixIndex * 3))).ToString("N" + decimalPlaces) + numberSuffix[suffixIndex - 1]; //return value in two decimal places with a post fix
                }
                else
                {
                    return Math.Floor(value).ToString(); //return value un-edited
                }
            }
            else if (method == 1) //if scientific notation method
            {
                /* Scientific Notation */
                return Math.Floor(value).ToString("0.00e0"); //scientific notation
            }
            else //if neither, return it unedited
            {
                return Math.Floor(value).ToString();
            }
        }
    }
}