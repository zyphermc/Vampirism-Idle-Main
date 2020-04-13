using TMPro;
using UnityEngine;

public class AscendManager : MonoBehaviour //Local (calculates the cost, info text, and amount of vampires available to ascend)
{
    //Managers
    public GameManager GameManager;

    public VampireManager VampireManager;
    public AmountButton AmountButton;
    public StatisticsWindow StatisticsWindow;

    //Vamp Stats Text Box
    public TextMeshProUGUI textBox_ButtonInfo;

    public string AscendButtonInfo;

    //Ascend Button Info Switch
    public bool[] ascendAvailable; //if there is n amount of vamps, make it true.

    public bool showAscendInfo; //if ascend button is hovered.
    public bool ascendBuyable;

    //Vampire Index
    public int vampIndex;

    private void Start()
    {
        showAscendInfo = false;
        ascendBuyable = false;
    }

    private void Update()
    {
        if (vampIndex != 9) //If vampire is not The Father
        {
            //If Max amount is chosen
            if (AmountButton.amountIndex == 6)
            {
                AscendButtonInfo = "Able to Ascend: " + GetAscendableAmount() + "\n"
                                   + "Blood Cost: " + GetAscendableAmount() * VampireManager.vampires_cost_ascend[vampIndex] + "\n"
                                   + "Vampire Cost: " + GetAscendableAmount() * 100;
            }
            else
            {
                AscendButtonInfo = "Amount to Ascend: " + AmountButton.amountNumber + "\n"
                                + "Blood Cost: " + AmountButton.amountNumber * VampireManager.vampires_cost_ascend[vampIndex] + "\n"
                                + "Vampire Cost: " + AmountButton.amountNumber * 100;
            }

            if (VampireManager.vampires_amount_Total[vampIndex] >= 100)
            {
                if (!ascendAvailable[vampIndex] && vampIndex != 9) //If ascend button is not available and vamps is more than 100, make it available
                {
                    ascendAvailable[vampIndex] = true;
                    Debug.Log("Ascend Available");
                }
            }

            if (ascendAvailable[vampIndex]) //if ascend unlocked, calculate if buyable
            {
                if (AmountButton.amountIndex == 6) //MAX
                {
                    if (VampireManager.vampires_amount_Total[vampIndex] >= 100 && GameManager.res_Blood >= VampireManager.vampires_cost_ascend[vampIndex])
                    {
                        ascendBuyable = true;
                    }
                    else
                    {
                        ascendBuyable = false;
                    }
                }
                else //if not max (1,10,25,50,100)
                {
                    //Check if total cost is met
                    if (VampireManager.vampires_amount_Total[vampIndex] >= 100 * AmountButton.amountNumber && GameManager.res_Blood >= VampireManager.vampires_cost_ascend[vampIndex] * AmountButton.amountNumber)
                    {
                        ascendBuyable = true;
                    }
                    else
                    {
                        ascendBuyable = false;
                    }
                }
            }
        }
    }

    public void ShowAscendInfo()
    {
        showAscendInfo = true;
        Debug.Log("showAscendInfo = true");
    }

    public void HideAscendInfo()
    {
        showAscendInfo = false;
        Debug.Log("showAscendInfo = false");
    }

    public void ascendVamp() //Function for ascending vampires  (TO DO: incorporate multiple ascensions in one click)
    {
        //If max
        if (AmountButton.amountIndex == 6)
        {
            //Log Event
            StatisticsWindow.AddEvent((100 * GetAscendableAmount()).ToString() + " " + VampireManager.vampires_name[vampIndex] + "s has turned into " + GetAscendableAmount() + " " + VampireManager.vampires_name[vampIndex + 1]);

            VampireManager.vampires_amount_Total[vampIndex + 1] += GetAscendableAmount();
            VampireManager.vampires_amount_Total[vampIndex] -= 100 * GetAscendableAmount();
            GameManager.res_Blood -= VampireManager.vampires_cost_ascend[vampIndex] * GetAscendableAmount();
        }
        else
        {
            //Log Event
            StatisticsWindow.AddEvent((100 * AmountButton.amountNumber).ToString() + " " + VampireManager.vampires_name[vampIndex] + "s has turned into " + AmountButton.amountNumber + " " + VampireManager.vampires_name[vampIndex + 1]);

            VampireManager.vampires_amount_Total[vampIndex + 1] += AmountButton.amountNumber;
            VampireManager.vampires_amount_Total[vampIndex] -= 100 * AmountButton.amountNumber;
            GameManager.res_Blood -= VampireManager.vampires_cost_ascend[vampIndex] * AmountButton.amountNumber;
        }
    }

    //Calculate Total Vampires able to ascend
    private int GetAscendableAmount()
    {
        int ascendable_Blood = Mathf.FloorToInt((float)(GameManager.res_Blood / VampireManager.vampires_cost_ascend[vampIndex]));
        int ascendable_Vamps = Mathf.FloorToInt((float)(VampireManager.vampires_amount_Total[vampIndex] / 100));

        //return which is less
        if (ascendable_Blood >= ascendable_Vamps)
        {
            return ascendable_Vamps;
        }
        else
        {
            return ascendable_Blood;
        }
    }
}