using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    //Button References (for enabling and disabling)
    public Button[] vampireButton;

    //Blood Gather Manager Object
    public BloodGatherManager BloodGatherManager;

    //Vampire Progress Bars (Lair)
    public TextMeshProUGUI[] Lair_ProgressBars;

    //Labor Manager
    public LaborManager LaborManager;

    //Vampire Stats
    public string[] vampires_name;

    public string[] vampires_quote;
    public string[] vampires_desc;

    public double[] vampires_speed; // value to add per second
    public double[] vampires_base_CompletionTime; //Time it takes to complete a cycle
    [HideInInspector] public double[] vampires_CompletionTimeTotal;

    public double[] vampires_base_BloodEfficiency;
    public double[] vampires_base_InfectionChance; //chance you infect someone and turn it into a vamp one tier below
    [HideInInspector] public double[] vampires_BloodEfficiencyTotal;
    [HideInInspector] public double[] vampires_InfectionChanceTotal;
    public double[] vampires_infectEfficiency;

    public double[] vampires_maximumBloodGather;

    public bool[] vampires_unlocked; //Switch for unlocking the vampire buttons

    [HideInInspector] public double[] vampires_bloodPerKill; //blood you get per kill
    [HideInInspector] public double[] vampires_bloodPerInfect; //blood you get when infecting humans (lower than per kill)

    [HideInInspector] public double[] vampires_currentProgress;
    [HideInInspector] public double[] vampires_progress;
    public double[] vampires_amount_Total;
    [HideInInspector] public double[] vampires_amount_Available_Total;
    [HideInInspector] public double[] vampires_amount_Used_Total;
    [HideInInspector] public double[] vampires_amount_Used_Feed;
    [HideInInspector] public double[] vampires_amount_Used_Infect;

    /* Upgrades */

    //Efficiency Upgrades
    public EfficiencyUpgrades EfficiencyUpgrades;

    //Ascend costs
    public double[] vampires_cost_ascend;

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
        vampires_base_BloodEfficiency[0] = 50; //out of 100
        //vampires_infectionChance[0] = 10; //out of 100
        //vampires_infectEfficiency[0] = 10;
        vampires_speed[0] = 1;
        vampires_base_CompletionTime[0] = 10;
        //////////////////////////////////////////////////////////////////////////////////////////////

        //Vampling Initial Stats
        vampires_name[1] = "Vampling";
        vampires_quote[1] = "Eyy I'm a vampling, sounds like a dumpling, but more dangerous.";
        vampires_desc[1] = "This is the next step to human evolution.";

        vampires_maximumBloodGather[1] = 7000;
        vampires_base_BloodEfficiency[1] = 45; //out of 100
        vampires_base_InfectionChance[1] = 45; //out of 100
        vampires_infectEfficiency[1] = 10;
        vampires_speed[1] = 1;
        vampires_base_CompletionTime[1] = 20;
        //////////////////////////////////////////////////////////////////////////////////////////////

        //Lesser Vampire Initial Stats
        vampires_name[2] = "Lesser Vampire";
        vampires_quote[2] = "Eyy I'm a Lesser Vampire, sounds like a fire pyre, but more dangerous.";
        vampires_desc[2] = "This is the next step to human evolution.";

        vampires_maximumBloodGather[2] = 30000;
        vampires_base_BloodEfficiency[2] = 40; //out of 100
        vampires_base_InfectionChance[2] = 40; //out of 100
        vampires_infectEfficiency[2] = 9;
        vampires_speed[2] = 1;
        vampires_base_CompletionTime[2] = 30;
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
                vampires_progress[a] = (vampires_currentProgress[a] / vampires_CompletionTimeTotal[a]); //update the progress of completion in lair

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

            if (a == 0) //If vampire is a fledgeling, add those in labor tab (wood and stone)
            {
                vampires_amount_Used_Total[a] = vampires_amount_Used_Feed[a] + vampires_amount_Used_Infect[a] + LaborManager.fledgelings_used_total;
            }
            else //if not, don't
            {
                vampires_amount_Used_Total[a] = vampires_amount_Used_Feed[a] + vampires_amount_Used_Infect[a];
            }

            vampires_BloodEfficiencyTotal[a] = vampires_base_BloodEfficiency[a] + (5 * EfficiencyUpgrades.level_SharpenFang[a]);
            vampires_InfectionChanceTotal[a] = vampires_base_InfectionChance[a] + (5 * EfficiencyUpgrades.level_SharpenFang[a]);

            vampires_CompletionTimeTotal[a] = vampires_base_CompletionTime[a] / (Mathf.Pow(2, EfficiencyUpgrades.level_TrainAgility[a]));

            vampires_bloodPerKill[a] = vampires_maximumBloodGather[a] * (vampires_BloodEfficiencyTotal[a] / 100f); //% out of 100
            vampires_bloodPerInfect[a] = vampires_maximumBloodGather[a] * (vampires_infectEfficiency[a] / 100f); //only 10% of max blood gather

            //Update button lock
            if (vampires_amount_Total[a] > 0 && vampires_unlocked[a] == false)
            {
                vampires_unlocked[a] = true;
            }

            //Check if button is unlocked, if yes show it, if no, hide it.
            if (vampires_unlocked[a])
            {
                vampireButton[a].gameObject.SetActive(true);
            }
            else
            {
                vampireButton[a].gameObject.SetActive(false);
            }
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