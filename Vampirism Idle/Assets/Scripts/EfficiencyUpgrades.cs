using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EfficiencyUpgrades : MonoBehaviour //Local
{
    public Button upgrade_SharpenFang;
    public Button upgrade_TrainAgility;
    public TextMeshProUGUI textBox_SharpenFang;
    public TextMeshProUGUI textBox_TrainAgility;
    public TextMeshProUGUI buttonDescription;

    //Upgrade variables
    public double[] baseCost_SharpenFang;
    public double[] baseCost_TrainAgility;
    public double[] growthRate_SharpenFang;
    public double[] growthRate_TrainAgility;
    public double[] cost_SharpenFang;
    public double[] cost_TrainAgility;
    public int[] level_SharpenFang;
    public int[] level_TrainAgility;

    //Vamp Index
    public int vampIndex;

    //Description Switches
    public bool hovered_SharpenFang;
    public bool hovered_TrainAgility;

    private void Update()
    {
        //Calculate Costs
        cost_SharpenFang[vampIndex] = baseCost_SharpenFang[vampIndex] * (Math.Pow(growthRate_SharpenFang[vampIndex], level_SharpenFang[vampIndex]));
        cost_TrainAgility[vampIndex] = baseCost_TrainAgility[vampIndex] * (Math.Pow(growthRate_TrainAgility[vampIndex], level_TrainAgility[vampIndex]));

        //Update Button Text
        textBox_SharpenFang.text = "Sharpen Fang \n(" + level_SharpenFang[vampIndex] + ")";
        textBox_TrainAgility.text = "Train Agility \n(" + level_TrainAgility[vampIndex] + ")";

        //Update Description Box
        if (hovered_SharpenFang)
        {
            buttonDescription.text = "sharpen fang lolol " + "[" + vampIndex + "]";
        }
        else
        if (hovered_TrainAgility)
        {
            buttonDescription.text = "train agility lolol " + "[" + vampIndex + "]";
        }
        else
        {
            buttonDescription.text = "";
        }
    }

    public void HoveringSharpenFang()
    {
        hovered_SharpenFang = true;
    }

    public void HoveringTrainAgility()
    {
        hovered_TrainAgility = true;
    }

    public void HoverExit()
    {
        hovered_SharpenFang = false;
        hovered_TrainAgility = false;
    }
}
