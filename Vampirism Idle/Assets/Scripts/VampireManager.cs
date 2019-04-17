using System.Collections;
using TMPro;
using UnityEngine;

public class VampireManager : MonoBehaviour //Persistent
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
    public string[] vampires_quote;
    public string[] vampires_desc;
    public double[] vampires_bloodEfficiency;
    public double[] vampires_maximumBloodGather;
    public double[] vampires_baseCost_sharpenFangs;
    public double[] vampires_baseCost_trainAgility;
    public double[] vampires_speed; // value to add per second
    public double[] vampires_completionTime; //Time it takes to complete a cycle
    [HideInInspector] public double[] vampires_currentProgress;
    [HideInInspector] public double[] vampires_Cost_sharpenFangs;
    [HideInInspector] public double[] vampires_Cost_trainAgility;
    [HideInInspector] public double[] vampires_progress;
    [HideInInspector] public int[] vampires_level_sharpenFangs;
    [HideInInspector] public int[] vampires_level_trainAgility;
    [HideInInspector] public int[] vampires_amount_Total;
    [HideInInspector] public int[] vampires_amount_Available_Total;
    [HideInInspector] public int[] vampires_amount_Used_Total;
    [HideInInspector] public int[] vampires_amount_Used_Feed;
    [HideInInspector] public int[] vampires_amount_Used_Infect;

    //Vampire Progress Bars (Lair)
    [HideInInspector] public TextMeshProUGUI[] Lair_ProgressBars;

    private void Start()
    {
        //Start Coroutines
        StartCoroutine("UpdateVampProgress");

        //Fledgeling Initial Stats
        vampires_name[0] = "Fledgeling";
        vampires_quote[0] = "I didn't sign up for this.";
        vampires_desc[0] = "Basically a freshly turned vampire.";

        vampires_maximumBloodGather[0] = 1000;
        vampires_bloodEfficiency[0] = 75 / 100;
        vampires_baseCost_sharpenFangs[0] = 5000;
        vampires_baseCost_trainAgility[0] = 7500;

        vampires_Cost_sharpenFangs[0] = 0;
        vampires_Cost_trainAgility[0] = 0;
        vampires_level_sharpenFangs[0] = 0;
        vampires_level_trainAgility[0] = 0;

        vampires_amount_Total[0] = 1;
        vampires_amount_Available_Total[0] = vampires_amount_Total[0] - vampires_amount_Used_Total[0];
        vampires_amount_Used_Total[0] = vampires_amount_Used_Feed[0] + vampires_amount_Used_Infect[0];
        vampires_amount_Used_Feed[0] = 0;
        vampires_amount_Used_Infect[0] = 0;

        //Vampling
        vampires_name[1] = "Vampling";
        vampires_quote[1] = "Eyy I'm a vampling, sounds like a dumpling, but more dangerous.";
        vampires_desc[1] = "This is the next step to human evolution.";

        vampires_maximumBloodGather[1] = 7000;
        vampires_bloodEfficiency[1] = 70 / 100;
        vampires_baseCost_sharpenFangs[1] = 100000;
        vampires_baseCost_trainAgility[1] = 100000;

        vampires_Cost_sharpenFangs[1] = 0;
        vampires_Cost_trainAgility[1] = 0;
        vampires_level_sharpenFangs[1] = 0;
        vampires_level_trainAgility[1] = 0;

        vampires_amount_Total[1] = 0;
        vampires_amount_Available_Total[1] = vampires_amount_Total[1] - vampires_amount_Used_Total[1];
        vampires_amount_Used_Total[1] = vampires_amount_Used_Feed[1] + vampires_amount_Used_Infect[1];
        vampires_amount_Used_Feed[1] = 0;
        vampires_amount_Used_Infect[1] = 0;
    }

    private void Update()
    {
        //Update Progress Bar for all available vamps
        for (int a = 0; a < 10; a++)
        {
            if (vampires_amount_Total[a] > 0)
            {
                vampires_progress[a] = (vampires_currentProgress[a] / vampires_completionTime[a]); //update the progress of completion in lair

                if (vampires_progress[a] >= 1)
                {
                    //do functions here
                    vampires_currentProgress[a] = 0;
                }

                if (Lair_ProgressBars[a].isActiveAndEnabled)
                {
                    Lair_ProgressBars[a].SetText((vampires_progress[a] * 100).ToString("F0") + "%");
                }
            }
        }
    }

    private IEnumerator UpdateVampProgress()
    {
        while (true)
        {
            for (int a = 0; a < 10; a++)
            {
                if (vampires_amount_Total[a] > 0)
                {
                    vampires_currentProgress[a] += vampires_speed[a] / 60f; //add the speed value to the current progress
                }
            }
            yield return new WaitForSeconds(1f / 60f);
        }
    }
}