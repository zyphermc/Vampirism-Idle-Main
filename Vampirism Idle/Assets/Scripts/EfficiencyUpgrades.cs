using NumberShortening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EfficiencyUpgrades : MonoBehaviour //Local
{
    //Resources References
    public GameManager GameManager;

    public VampireManager VampireManager;

    //Shortening Number Object
    public ShortenNumber sn = new ShortenNumber();

    //UI References
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

    //Temporary Variables
    private double newEfficiency;

    private double newSpeed;

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
            if (level_SharpenFang[vampIndex] == 10)
            {
                buttonDescription.text = "Sharpen Fang Upgrade Maxed" + "\n"
                                         + "Efficiency: " + VampireManager.vampires_BloodEfficiencyTotal[vampIndex] + "%";
            }
            else
            {
                if (vampIndex == 0)
                {
                    newEfficiency = VampireManager.vampires_BloodEfficiencyTotal[vampIndex] + 5;

                    buttonDescription.text = "Sharpen Fangs:" + "\n"
                    + "Increase Feed Efficiency by 5%" + "\n"
                    + VampireManager.vampires_BloodEfficiencyTotal[vampIndex] + "% -> " + newEfficiency + "%\n"
                    + "Cost (Blood): " + sn.shortenNumber(cost_SharpenFang[vampIndex], sn.shortenMethod, 2);
                }
                else
                {
                    newEfficiency = VampireManager.vampires_BloodEfficiencyTotal[vampIndex] + 5;

                    buttonDescription.text = "Sharpen Fangs:" + "\n"
                    + "Increase Feed Efficiency and Infection Chance by 5%" + "\n"
                    + VampireManager.vampires_BloodEfficiencyTotal[vampIndex] + "% -> " + newEfficiency + "%\n"
                    + "Cost (Blood): " + sn.shortenNumber(cost_SharpenFang[vampIndex], sn.shortenMethod, 2);
                }
            }
        }
        else
        if (hovered_TrainAgility)
        {
            if (level_TrainAgility[vampIndex] == 5)
            {
                buttonDescription.text = "Train Agility Upgrade Maxed" + "\n"
                                         + "Speed: " + VampireManager.vampires_CompletionTimeTotal[vampIndex] + "seconds";
            }
            else
            {
                newSpeed = VampireManager.vampires_CompletionTimeTotal[vampIndex] / 2f;

                buttonDescription.text = "Train Agility:" + "\n"
                + "Halve your vampire's completion time." + "\n"
                + VampireManager.vampires_CompletionTimeTotal[vampIndex] + " seconds -> " + newSpeed + " seconds" + "\n"
                + "Cost (Blood): " + sn.shortenNumber(cost_TrainAgility[vampIndex], sn.shortenMethod, 2);
            }
        }
        else
        {
            buttonDescription.text = "";
        }
    }

    /* Purchasing the upgrade functions */

    public void BuyUpgrade_SharpenFang()
    {
        if (GameManager.res_Blood >= cost_SharpenFang[vampIndex] && level_SharpenFang[vampIndex] < 10)
        {
            GameManager.res_Blood -= cost_SharpenFang[vampIndex];
            level_SharpenFang[vampIndex]++;
        }
    }

    public void BuyUpgrade_TrainAgility()
    {
        if (GameManager.res_Blood >= cost_TrainAgility[vampIndex] && level_TrainAgility[vampIndex] < 5)
        {
            GameManager.res_Blood -= cost_TrainAgility[vampIndex];
            level_TrainAgility[vampIndex]++;
        }
    }

    /* Hover Functions */

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