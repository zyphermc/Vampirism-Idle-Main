using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodGatherManager : MonoBehaviour //Persistent
{
    public GameManager GameManager;
    public VampireManager VampireManager;

    public int vampIndex; //index of vampire

    public void CommenceFeed()
    {
        if(GameManager.res_HumanPop >= VampireManager.vampires_amount_Used_Feed[vampIndex])
        {
            GameManager.res_Blood += VampireManager.vampires_bloodPerKill[vampIndex] * VampireManager.vampires_amount_Used_Feed[vampIndex];
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
        //Blood Gather Code (has errors)
        if (GameManager.res_HumanPop >= VampireManager.vampires_amount_Used_Infect[vampIndex])
        {
            if (VampireManager.vampires_amount_Used_Infect[vampIndex] <= 10) //calculate for n amount of times
            {
                for (int a = 0; a < VampireManager.vampires_amount_Used_Infect[vampIndex]; a++) //If less than 10, calculate chance for each vamp
                {
                    if (Random.value < 0.10f) //10% of infection
                    {
                        VampireManager.vampires_amount_Total[vampIndex - 1]++;
                    }
                }
            }
            else
            {
                VampireManager.vampires_amount_Total[vampIndex - 1] += Mathf.FloorToInt(VampireManager.vampires_amount_Used_Infect[vampIndex] * 0.10f);
            }

            GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex] * VampireManager.vampires_amount_Used_Infect[vampIndex];
            GameManager.res_HumanPop -= VampireManager.vampires_amount_Used_Infect[vampIndex];
        }
        else
        {
            //Infection Code
            if (VampireManager.vampires_amount_Used_Infect[vampIndex] <= 10)
            {
                for (int a = 0; a < GameManager.res_HumanPop; a++) //If less than 10, calculate chance for each human (there will be less than 10 humans)
                {
                    if (Random.value < 0.10f) //10% of infection
                    {
                        VampireManager.vampires_amount_Total[vampIndex - 1]++;
                    }
                }
            }
            else
            {
                VampireManager.vampires_amount_Total[vampIndex - 1] += Mathf.FloorToInt(GameManager.res_HumanPop * 0.10f);
            }

            GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex] * GameManager.res_HumanPop;
            GameManager.res_HumanPop = 0;
        }
    }
}
