using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountButton : MonoBehaviour
{
    public TextMeshProUGUI textBox_AmountButton;
    public int[] amountNumber;
    public int amountIndex;

    public void ChangeAmount()
    {
        if(amountIndex != 6)
        {
            amountIndex++;
        }
        else
        {
            amountIndex = 0;
        }

        if(amountIndex < 6)
        {
            textBox_AmountButton.text = (amountNumber[amountIndex] + "x");
        }
        else
        {
            textBox_AmountButton.text = ("MAX");
        }

        Debug.Log("Amount Index: " + amountIndex);
    }
}
