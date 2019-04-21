using System.Collections;
using TMPro;
using UnityEngine;

public class VampireManager : MonoBehaviour //Persistent (contains vamp stats)
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

    //Blood Gather Manager Object
    public BloodGatherManager BloodGatherManager;

    //Vampire Progress Bars (Lair)
    public TextMeshProUGUI[] Lair_ProgressBars;

    public string[] vampires_name;
    public string[] vampires_quote;
    public string[] vampires_desc;

    public double[] vampires_baseCost_sharpenFangs;
    public double[] vampires_baseCost_trainAgility;

    public double[] vampires_speed; // value to add per second
    public double[] vampires_completionTime; //Time it takes to complete a cycle

    public double[] vampires_bloodEfficiency;
    public double[] vampires_infectEfficiency;

    public double[] vampires_maximumBloodGather;

    [HideInInspector] public double[] vampires_bloodPerKill; //blood you get per kill
    [HideInInspector] public double[] vampires_bloodPerInfect; //blood you get when infecting humans (lower than per kill)
    public double[] vampires_infectionChance; //chance you infect someone and turn it into a vamp one tier below

    [HideInInspector] public double[] vampires_currentProgress;
    [HideInInspector] public double[] vampires_Cost_sharpenFangs; //cost after calculation
    [HideInInspector] public double[] vampires_Cost_trainAgility; //cost after calculation
    [HideInInspector] public double[] vampires_progress;
    [HideInInspector] public int[] vampires_level_sharpenFangs;
    [HideInInspector] public int[] vampires_level_trainAgility;
    [HideInInspector] public int[] vampires_amount_Total;
    [HideInInspector] public int[] vampires_amount_Available_Total;
    [HideInInspector] public int[] vampires_amount_Used_Total;
    [HideInInspector] public int[] vampires_amount_Used_Feed;
    [HideInInspector] public int[] vampires_amount_Used_Infect;

    //Vampire Slider Values (Lair)
    public int slider_maxValue;
    public float[] slider_savedMaxValueFeed;
    public float[] slider_savedMaxValueInfect;
    public int[] slider_usedFeed;
    public int[] slider_usedInfect;

    private void Start()
    {
        //Start Coroutines
        StartCoroutine("UpdateVampProgress");

        //Fledgeling Initial Stats
        vampires_name[0] = "Fledgeling";
        vampires_quote[0] = "I didn't sign up for this.";
        vampires_desc[0] = "Basically a freshly turned vampire.";

        vampires_maximumBloodGather[0] = 1000;
        vampires_bloodEfficiency[0] = 75; //out of 100
        //vampires_infectionChance[0] = 10; //out of 100
        //vampires_infectEfficiency[0] = 10;
        vampires_speed[0] = 1;
        vampires_completionTime[0] = 10;

        vampires_baseCost_sharpenFangs[0] = 5000;
        vampires_baseCost_trainAgility[0] = 7500;

        vampires_Cost_sharpenFangs[0] = 0;
        vampires_Cost_trainAgility[0] = 0;
        vampires_level_sharpenFangs[0] = 0;
        vampires_level_trainAgility[0] = 0;

        vampires_amount_Total[0] = 0;
        vampires_amount_Used_Total[0] = 0;
        vampires_amount_Used_Feed[0] = 0;
        vampires_amount_Used_Infect[0] = 0;
        //////////////////////////////////////////////////////////////////////////////////////////////

        //Vampling Initial Stats
        vampires_name[1] = "Vampling";
        vampires_quote[1] = "Eyy I'm a vampling, sounds like a dumpling, but more dangerous.";
        vampires_desc[1] = "This is the next step to human evolution.";

        vampires_maximumBloodGather[1] = 7000;
        vampires_bloodEfficiency[1] = 70; //out of 100
        vampires_infectionChance[1] = 10; //out of 100
        vampires_infectEfficiency[1] = 10;
        vampires_speed[1] = 1;
        vampires_completionTime[1] = 20;

        vampires_baseCost_sharpenFangs[1] = 100000;
        vampires_baseCost_trainAgility[1] = 100000;

        vampires_Cost_sharpenFangs[1] = 0;
        vampires_Cost_trainAgility[1] = 0;
        vampires_level_sharpenFangs[1] = 0;
        vampires_level_trainAgility[1] = 0;

        vampires_amount_Total[1] = 100;
        vampires_amount_Used_Total[1] = 0;
        vampires_amount_Used_Feed[1] = 0;
        vampires_amount_Used_Infect[1] = 0;
        //////////////////////////////////////////////////////////////////////////////////////////////

        //Lesser Vampire Initial Stats
        vampires_name[2] = "Lesser Vampire";
        vampires_quote[2] = "Eyy I'm a Lesser Vampire, sounds like a fire pyre, but more dangerous.";
        vampires_desc[2] = "This is the next step to human evolution.";

        vampires_maximumBloodGather[2] = 30000;
        vampires_bloodEfficiency[2] = 65; //out of 100
        vampires_infectionChance[2] = 9; //out of 100
        vampires_infectEfficiency[2] = 9;
        vampires_speed[2] = 1;
        vampires_completionTime[2] = 30;

        vampires_baseCost_sharpenFangs[2] = 1000000;
        vampires_baseCost_trainAgility[2] = 1000000;

        vampires_Cost_sharpenFangs[2] = 0;
        vampires_Cost_trainAgility[2] = 0;
        vampires_level_sharpenFangs[2] = 0;
        vampires_level_trainAgility[2] = 0;

        vampires_amount_Total[2] = 0;
        vampires_amount_Used_Total[2] = 0;
        vampires_amount_Used_Feed[2] = 0;
        vampires_amount_Used_Infect[2] = 0;
        //////////////////////////////////////////////////////////////////////////////////////////////
    }

    private void Update()
    {
        //Update all vamps
        for (int a = 0; a < 10; a++) //10 types of vamps currently
        {
            //Update Progress Bar for all available vamps
            if (vampires_amount_Used_Total[a] > 0)
            {
                vampires_progress[a] = (vampires_currentProgress[a] / vampires_completionTime[a]); //update the progress of completion in lair

                if (vampires_progress[a] >= 1)
                {
                    //do functions here
                    BloodGatherManager.vampIndex = a;
                    BloodGatherManager.CommenceFeed();
                    BloodGatherManager.CommenceInfect();


                    //reset progress after cycle
                    vampires_currentProgress[a] = 0;
                }

                if (Lair_ProgressBars[a].isActiveAndEnabled)
                {
                    Lair_ProgressBars[a].SetText((vampires_progress[a] * 100).ToString("F0") + "%");
                }
            }

            //Update Vampire Stats
            vampires_amount_Available_Total[a] = vampires_amount_Total[a] - vampires_amount_Used_Total[a];
            vampires_amount_Used_Total[a] = vampires_amount_Used_Feed[a] + vampires_amount_Used_Infect[a];

            vampires_bloodPerKill[a] = vampires_maximumBloodGather[a] * (vampires_bloodEfficiency[a] / 100f);
            vampires_bloodPerInfect[a] = vampires_maximumBloodGather[a] * (vampires_infectEfficiency[a] / 100f); //only 10% of max blood gather
        }
    }

    private IEnumerator UpdateVampProgress()
    {
        while (true)
        {
            for (int a = 0; a < 10; a++)
            {
                if (vampires_amount_Used_Feed[a] > 0 || vampires_amount_Used_Infect[a] > 0)
                {
                    vampires_currentProgress[a] += vampires_speed[a] / 60f; //add the speed value to the current progress
                }
            }
            yield return new WaitForSeconds(1f / 60f);
        }
    }
}