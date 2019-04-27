using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BloodGatherManager : MonoBehaviour //Persistent
{
    public GameManager GameManager;
    public VampireManager VampireManager;
    public HousingManager HousingManager;

    public int vampIndex; //index of vampire
    public int vampiresToAdd;

    public void CommenceFeed()
    {
        if (GameManager.res_HumanPop >= VampireManager.vampires_amount_Used_Feed[vampIndex])
        {
            GameManager.res_Blood +=
                VampireManager.vampires_bloodPerKill[vampIndex]
              * VampireManager.vampires_amount_Used_Feed[vampIndex];

            GameManager.res_HumanPop -= VampireManager.vampires_amount_Used_Feed[vampIndex];
        }
        else
        {
            GameManager.res_Blood += VampireManager.vampires_bloodPerKill[vampIndex] * GameManager.res_HumanPop;
            GameManager.res_HumanPop = 0;
        }
    }

    public void CommenceInfect()
    {
        //If Vamps less than or equal to 10, Human more than Vamps (Condition 1)
        if (VampireManager.vampires_amount_Used_Infect[vampIndex] <= 10 && GameManager.res_HumanPop >= VampireManager.vampires_amount_Used_Infect[vampIndex])
        {
            for (int a = 0; a < VampireManager.vampires_amount_Used_Infect[vampIndex]; a++) //If less than 10, calculate chance for each vamp
            {
                if (Random.value < (VampireManager.vampires_InfectionChanceTotal[vampIndex]/100f) && HousingManager.housing_amountAvailable > 0) //10% of infection
                {
                    VampireManager.vampires_amount_Total[vampIndex - 1]++;
                }
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex];
                GameManager.res_HumanPop -= 1;
            }
        }
        else
        //If Vamps less than or equal to 10, Human less than Vamps (Condition 2)
        if (VampireManager.vampires_amount_Used_Infect[vampIndex] <= 10 && GameManager.res_HumanPop < VampireManager.vampires_amount_Used_Infect[vampIndex])
        {
            for (int a = 0; a < GameManager.res_HumanPop; a++) //If less than 10, calculate chance for each vamp
            {
                if (Random.value < (VampireManager.vampires_InfectionChanceTotal[vampIndex] / 100f) && HousingManager.housing_amountAvailable > 0) //10% of infection
                {
                    VampireManager.vampires_amount_Total[vampIndex - 1]++;
                }
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex];
                GameManager.res_HumanPop -= 1;
            }
        }
        else
        //If Vamps more than 10 (Condition 3)
        if (VampireManager.vampires_amount_Used_Infect[vampIndex] > 10)
        {
            //If Human more than Vamps (Condition 3.1)
            if (GameManager.res_HumanPop >= VampireManager.vampires_amount_Used_Infect[vampIndex])
            {
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex] * VampireManager.vampires_amount_Used_Infect[vampIndex]; //add blood
                GameManager.res_HumanPop -= VampireManager.vampires_amount_Used_Infect[vampIndex]; //decrease pop

                /* Infection Code */
                vampiresToAdd = Mathf.FloorToInt(VampireManager.vampires_amount_Used_Infect[vampIndex] * (float)(VampireManager.vampires_InfectionChanceTotal[vampIndex] / 100f)); //calculate amount of vampires to add; 10% of vamps will convert a human

                //If housing is greater than the vampires to be added
                if (HousingManager.housing_amountAvailable > vampiresToAdd)
                {
                    VampireManager.vampires_amount_Total[vampIndex - 1] += vampiresToAdd; //add the vamps
                }
                else //If the vampires to be added is greater than the housing, fill the housing instead.
                {
                    VampireManager.vampires_amount_Total[vampIndex - 1] += HousingManager.housing_amountAvailable;
                }
                /////////////////////////
            }
            else //If Human less than Vamps (Condition 3.2)
            {
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex] * GameManager.res_HumanPop;

                vampiresToAdd = Mathf.FloorToInt(VampireManager.vampires_amount_Used_Infect[vampIndex] * (float)(VampireManager.vampires_InfectionChanceTotal[vampIndex] / 100f));

                //If vampires to be added is greater than the pop, convert all humans to vamps
                if (vampiresToAdd > GameManager.res_HumanPop)
                {
                    if (HousingManager.housing_amountAvailable > GameManager.res_HumanPop)
                    {
                        VampireManager.vampires_amount_Total[vampIndex - 1] += GameManager.res_HumanPop;
                    }
                    else
                    {
                        VampireManager.vampires_amount_Total[vampIndex - 1] += HousingManager.housing_amountAvailable;
                    }

                    GameManager.res_HumanPop = 0;
                }
                else //If humans are greater than the vampires to be added, add that instead.
                {
                    if (HousingManager.housing_amountAvailable > vampiresToAdd)
                    {
                        VampireManager.vampires_amount_Total[vampIndex - 1] += vampiresToAdd;
                    }
                    else
                    {
                        VampireManager.vampires_amount_Total[vampIndex - 1] += HousingManager.housing_amountAvailable;
                    }
                    GameManager.res_HumanPop -= vampiresToAdd;
                }
            }
        }
    }
}