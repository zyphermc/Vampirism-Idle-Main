using TMPro;
using UnityEngine;

public class AmountButton : MonoBehaviour //Local
{
    public TextMeshProUGUI textBox_AmountButton;
    public int[] amountArray;
    public int amountIndex;  //index 6 is MAX
    public int amountNumber;

    public void Update()
    {
        amountNumber = amountArray[amountIndex];
    }

    public void ChangeAmount()
    {
        if (amountIndex != 6)
        {
            amountIndex++;
        }
        else
        {
            amountIndex = 0;
        }

        if (amountIndex < 6)
        {
            textBox_AmountButton.text = (amountArray[amountIndex] + "x");

            Debug.Log("Amount Number: " + amountNumber);
        }
        else
        {
            textBox_AmountButton.text = ("MAX");
        }

        Debug.Log("Amount Index: " + amountIndex);
    }
}