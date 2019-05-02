using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumberShortening
{
    public class ShortenNumber
    {
        public string shortenNumber(double value)
        {
            int zeroAmount = (int)Math.Log10(value);
            
            if(zeroAmount > 2) //if more than hundredths
            {
                return value.ToString("0.00e0"); //scientific notation
            }
            else
            {
                return value.ToString();
            }
            
        }
    }

}
