using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireManager : MonoBehaviour
{
    /* This contains the stats of every vampire */

        /*Vampire List
         * Fledgeling
         * Vampling
         * Lesser Vampire
         * Greater Vampire
         * Coven Lord
         * Necromancer
         * Highborne
         * Royal Guard
         * Blood King
         * The Father
         */

    public string[] vampires_name;
    public double[] vampires_bloodEfficiency;
    public double[] vampires_maximumBloodGather;
    public double[] vampires_baseCost_sharpenFangs;
    public double[] vampires_baseCost_trainAgility;
    public double[] vampires_Cost_sharpenFangs;
    public double[] vampires_Cost_trainAgility;
    public int[] vampires_level_sharpenFangs;
    public int[] vampires_level_trainAgility;
    public int[] vampires_amount_Total;
    public int[] vampires_amount_Used_Total;
    public int[] vampires_amount_Used_Feed;
    public int[] vampires_amount_Used_Infect;

    private void Start()
    {
        //Fledgeling Initial Stats
        vampires_name[0] = "Fledgeling";
        vampires_maximumBloodGather[0] = 1000;
        vampires_bloodEfficiency[0] = 75 / 100;
        vampires_baseCost_sharpenFangs[0] = 5000;
        vampires_baseCost_trainAgility[0] = 7500;

        vampires_Cost_sharpenFangs[0] = 0;
        vampires_Cost_trainAgility[0] = 0;
        vampires_level_sharpenFangs[0] = 0;
        vampires_level_trainAgility[0] = 0;

        vampires_amount_Total[0] = 0;
        vampires_amount_Used_Total[0] = vampires_amount_Used_Feed[0] + vampires_amount_Used_Infect[0];
        vampires_amount_Used_Feed[0] = 0;
        vampires_amount_Used_Infect[0] = 0;

        
    }

}
