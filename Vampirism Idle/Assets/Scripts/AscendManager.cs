using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class AscendManager : MonoBehaviour //Local (calculates the cost, info text, and amount of vampires available to ascend)
{
    //Managers
    public GameManager GameManager;
    public VampireManager VampireManager;

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
        //If Max amount is chosen
        AscendButtonInfo = "Amount to Ascend: " + GetAscendableAmount() +  "\n"
            + "Blood Cost: " + GetAscendableAmount() * VampireManager.vampires_cost_ascend[vampIndex] + "\n"
            + "Vampire Cost: " + GetAscendableAmount() * 100;

        
        


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
            if(VampireManager.vampires_amount_Total[vampIndex] >= 100 && GameManager.res_Blood >= VampireManager.vampires_cost_ascend[vampIndex])
            {
                ascendBuyable = true;
            }
            else
            {
                ascendBuyable = false;
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
        VampireManager.vampires_amount_Total[vampIndex + 1]++;
        VampireManager.vampires_amount_Total[vampIndex] -= 100;
        GameManager.res_Blood -= VampireManager.vampires_cost_ascend[vampIndex];

        Debug.Log("Vampire Ascended lmao");
    }

    //Calculate Total Vampires able to ascend
    private int GetAscendableAmount()
    {
        int ascendable_Blood = Mathf.FloorToInt((float)(GameManager.res_Blood / VampireManager.vampires_cost_ascend[vampIndex]));
        int ascendable_Vamps = Mathf.FloorToInt((float)(VampireManager.vampires_amount_Total[vampIndex] / 100));

        if (ascendable_Blood >= ascendable_Vamps)
        {
            return ascendable_Blood;
        }
        else
        {
            return ascendable_Vamps;
        }
    }
}
