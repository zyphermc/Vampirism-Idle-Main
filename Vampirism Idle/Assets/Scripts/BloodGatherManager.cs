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
        if(VampireManager.vampires_amount_Used_Infect[vampIndex] <= 10 && GameManager.res_HumanPop >= VampireManager.vampires_amount_Used_Infect[vampIndex])
        {
            for (int a = 0; a < VampireManager.vampires_amount_Used_Infect[vampIndex]; a++) //If less than 10, calculate chance for each vamp
            {
                if (Random.value < 0.10f) //10% of infection
                {
                    VampireManager.vampires_amount_Total[vampIndex - 1]++;
                }
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex];
                GameManager.res_HumanPop -= 1;
            }
        }else
        //If Vamps less than or equal to 10, Human less than Vamps (Condition 2)
        if(VampireManager.vampires_amount_Used_Infect[vampIndex] <= 10 && GameManager.res_HumanPop < VampireManager.vampires_amount_Used_Infect[vampIndex])
        {
            for (int a = 0; a < GameManager.res_HumanPop; a++) //If less than 10, calculate chance for each vamp
            {
                if (Random.value < 0.10f) //10% of infection
                {
                    VampireManager.vampires_amount_Total[vampIndex - 1]++;
                }
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex];
                GameManager.res_HumanPop -= 1;
            }
        }
        else
        //If Vamps more than 10 (Condition 3)
        if(VampireManager.vampires_amount_Used_Infect[vampIndex] > 10)
        {
            //If Human more than Vamps (Condition 3.1)
            if (GameManager.res_HumanPop >= VampireManager.vampires_amount_Used_Infect[vampIndex])
            {
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex] * VampireManager.vampires_amount_Used_Infect[vampIndex];

                VampireManager.vampires_amount_Total[vampIndex - 1] += Mathf.FloorToInt(VampireManager.vampires_amount_Used_Infect[vampIndex] * 0.10f); //10% of vamps will convert a human

                GameManager.res_HumanPop -= VampireManager.vampires_amount_Used_Infect[vampIndex];
            }
            else //If Human less than Vamps (Condition 3.2)
            {
                GameManager.res_Blood += VampireManager.vampires_bloodPerInfect[vampIndex] * GameManager.res_HumanPop;

                VampireManager.vampires_amount_Total[vampIndex - 1] += Mathf.FloorToInt(GameManager.res_HumanPop * 0.10f); //turn 10% of human pop to vamps

                GameManager.res_HumanPop = 0;
            }
            
        }
    }
}
