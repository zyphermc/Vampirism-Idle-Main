using NumberShortening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HousingManager : MonoBehaviour
{
    //Object References
    public VampireManager VampireManager;

    public TextMeshProUGUI textBox_housingLair;

    public ShortenNumber sn = new ShortenNumber();

    public Button[] vamp_house_button;
    public Button[] human_house_button;

    public GameObject obj_vampDesc;
    public GameObject obj_humanDesc;

    /*Declaration of housing variables*/

    //Vampire Housing Variables
    public double vamp_housing_baseCap;

    public double vamp_housing_amountAvailable;

    public double vamp_housing_amountTotal;
    public double vamp_housing_amountUsed;

    [HideInInspector] public string[] vamp_housing_buildingName;
    [HideInInspector] public string[] vamp_housing_buildingDesc;
    [HideInInspector] public double[] vamp_housing_buildingBaseCap;
    public double[] vamp_housing_buildingAmount;
    [HideInInspector] public double[] vamp_housing_buildingTotalCap;
    [HideInInspector] public double[] vamp_housing_buildingCost_wood;
    [HideInInspector] public double[] vamp_housing_buildingCost_stone;

    //Human Housing Variables
    [HideInInspector] public string[] human_housing_buildingName;

    [HideInInspector] public string[] human_housing_buildingDesc;
    [HideInInspector] public double[] human_housing_buildingBaseProduction;
    public double[] human_housing_buildingAmount;
    [HideInInspector] public double[] human_housing_buildingTotalProduction;
    [HideInInspector] public double[] human_housing_buildingCost_wood;
    [HideInInspector] public double[] human_housing_buildingCost_stone;

    //House button lock variables
    private bool[] vamp_building_unlocked = new bool[10]; //amount of building types

    private bool[] human_building_unlocked = new bool[10];

    //House button manager
    public int vamp_housing_infoNum = -1;

    public int human_housing_infoNum = -1;

    //Amount of building types
    private int buildingTypes = 10;

    private void Start()
    {
        #region Vampire and Human Housing Stats

        /* VAMPIRE HOUSING INITIALIZATION */
        vamp_housing_baseCap = 10; //Starting housing for vampires

        vamp_housing_buildingName[0] = "Tent";
        vamp_housing_buildingDesc[0] = "A small tent built with sticks";
        vamp_housing_buildingBaseCap[0] = 10;
        vamp_housing_buildingAmount[0] = 0;
        vamp_housing_buildingCost_stone[0] = 10;
        vamp_housing_buildingCost_wood[0] = 10;
        vamp_building_unlocked[0] = true;

        vamp_housing_buildingName[1] = "Small Shack";
        vamp_housing_buildingDesc[1] = "A small shack built with sticks";
        vamp_housing_buildingBaseCap[1] = 50;
        vamp_housing_buildingAmount[1] = 0;
        vamp_housing_buildingCost_stone[1] = 100;
        vamp_housing_buildingCost_wood[1] = 100;
        vamp_building_unlocked[1] = false;

        vamp_housing_buildingName[2] = "Big Shack";
        vamp_housing_buildingDesc[2] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[2] = 100;
        vamp_housing_buildingAmount[2] = 0;
        vamp_housing_buildingCost_stone[2] = 1000;
        vamp_housing_buildingCost_wood[2] = 1000;
        vamp_building_unlocked[2] = false;

        vamp_housing_buildingName[3] = "Big Shack2";
        vamp_housing_buildingDesc[3] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[3] = 1000;
        vamp_housing_buildingAmount[3] = 0;
        vamp_housing_buildingCost_stone[3] = 10000;
        vamp_housing_buildingCost_wood[3] = 10000;
        vamp_building_unlocked[3] = false;

        vamp_housing_buildingName[4] = "Big Shack3";
        vamp_housing_buildingDesc[4] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[4] = 10000;
        vamp_housing_buildingAmount[4] = 0;
        vamp_housing_buildingCost_stone[4] = 100000;
        vamp_housing_buildingCost_wood[4] = 100000;
        vamp_building_unlocked[4] = false;

        vamp_housing_buildingName[5] = "Big Shack4";
        vamp_housing_buildingDesc[5] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[5] = 100000;
        vamp_housing_buildingAmount[5] = 0;
        vamp_housing_buildingCost_stone[5] = 1000000;
        vamp_housing_buildingCost_wood[5] = 1000000;
        vamp_building_unlocked[5] = false;

        vamp_housing_buildingName[6] = "Big Shack5";
        vamp_housing_buildingDesc[6] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[6] = 1000000;
        vamp_housing_buildingAmount[6] = 0;
        vamp_housing_buildingCost_stone[6] = 10000000;
        vamp_housing_buildingCost_wood[6] = 10000000;
        vamp_building_unlocked[6] = false;

        vamp_housing_buildingName[7] = "Big Shack6";
        vamp_housing_buildingDesc[7] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[7] = 10000000;
        vamp_housing_buildingAmount[7] = 0;
        vamp_housing_buildingCost_stone[7] = 100000000;
        vamp_housing_buildingCost_wood[7] = 100000000;
        vamp_building_unlocked[7] = false;

        vamp_housing_buildingName[8] = "Big Shack7";
        vamp_housing_buildingDesc[8] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[8] = 100000000;
        vamp_housing_buildingAmount[8] = 0;
        vamp_housing_buildingCost_stone[8] = 1000000000;
        vamp_housing_buildingCost_wood[8] = 1000000000;
        vamp_building_unlocked[8] = false;

        vamp_housing_buildingName[9] = "Big Shack8";
        vamp_housing_buildingDesc[9] = "A big shack built with sticks";
        vamp_housing_buildingBaseCap[9] = 1000000000;
        vamp_housing_buildingAmount[9] = 0;
        vamp_housing_buildingCost_stone[9] = 10000000000;
        vamp_housing_buildingCost_wood[9] = 10000000000;
        vamp_building_unlocked[9] = false;
        //---------------------------------------------------------------------

        /* HUMAN HOUSING INITIALIZATION */
        human_housing_buildingName[0] = "HumanBuilding1";
        human_housing_buildingDesc[0] = "HumanDesc1";
        human_housing_buildingBaseProduction[0] = 1;
        human_housing_buildingAmount[0] = 0;
        human_housing_buildingCost_stone[0] = 10;
        human_housing_buildingCost_wood[0] = 10;
        human_building_unlocked[0] = true;

        human_housing_buildingName[1] = "HumanBuilding2";
        human_housing_buildingDesc[1] = "HumanDesc2";
        human_housing_buildingBaseProduction[1] = 10;
        human_housing_buildingAmount[1] = 0;
        human_housing_buildingCost_stone[1] = 100;
        human_housing_buildingCost_wood[1] = 100;
        human_building_unlocked[1] = false;

        human_housing_buildingName[2] = "HumanBuilding3";
        human_housing_buildingDesc[2] = "HumanDesc3";
        human_housing_buildingBaseProduction[2] = 100;
        human_housing_buildingAmount[2] = 0;
        human_housing_buildingCost_stone[2] = 1000;
        human_housing_buildingCost_wood[2] = 1000;
        human_building_unlocked[2] = false;

        human_housing_buildingName[3] = "HumanBuilding4";
        human_housing_buildingDesc[3] = "HumanDesc4";
        human_housing_buildingBaseProduction[3] = 1000;
        human_housing_buildingAmount[3] = 0;
        human_housing_buildingCost_stone[3] = 10000;
        human_housing_buildingCost_wood[3] = 10000;
        human_building_unlocked[3] = false;

        human_housing_buildingName[4] = "HumanBuilding5";
        human_housing_buildingDesc[4] = "HumanDesc5";
        human_housing_buildingBaseProduction[4] = 10000;
        human_housing_buildingAmount[4] = 0;
        human_housing_buildingCost_stone[4] = 100000;
        human_housing_buildingCost_wood[4] = 100000;
        human_building_unlocked[4] = false;

        human_housing_buildingName[5] = "HumanBuilding6";
        human_housing_buildingDesc[5] = "HumanDesc6";
        human_housing_buildingBaseProduction[5] = 100000;
        human_housing_buildingAmount[5] = 0;
        human_housing_buildingCost_stone[5] = 1000000;
        human_housing_buildingCost_wood[5] = 1000000;
        human_building_unlocked[5] = false;

        human_housing_buildingName[6] = "HumanBuilding7";
        human_housing_buildingDesc[6] = "HumanDesc7";
        human_housing_buildingBaseProduction[6] = 1000000;
        human_housing_buildingAmount[6] = 0;
        human_housing_buildingCost_stone[6] = 10000000;
        human_housing_buildingCost_wood[6] = 10000000;
        human_building_unlocked[6] = false;

        human_housing_buildingName[7] = "HumanBuilding8";
        human_housing_buildingDesc[7] = "HumanDesc8";
        human_housing_buildingBaseProduction[7] = 10000000;
        human_housing_buildingAmount[7] = 0;
        human_housing_buildingCost_stone[7] = 100000000;
        human_housing_buildingCost_wood[7] = 100000000;
        human_building_unlocked[7] = false;

        human_housing_buildingName[8] = "HumanBuilding9";
        human_housing_buildingDesc[8] = "HumanDesc9";
        human_housing_buildingBaseProduction[8] = 100000000;
        human_housing_buildingAmount[8] = 0;
        human_housing_buildingCost_stone[8] = 1000000000;
        human_housing_buildingCost_wood[8] = 1000000000;
        human_building_unlocked[8] = false;

        human_housing_buildingName[9] = "HumanBuilding10";
        human_housing_buildingDesc[9] = "HumanDesc10";
        human_housing_buildingBaseProduction[9] = 1000000000;
        human_housing_buildingAmount[9] = 0;
        human_housing_buildingCost_stone[9] = 10000000000;
        human_housing_buildingCost_wood[9] = 10000000000;
        human_building_unlocked[9] = false;

        //Disable house description at start
        obj_vampDesc.SetActive(false);
        obj_humanDesc.SetActive(false);

        #endregion Vampire and Human Housing Stats
    }

    private void Update()
    {
        //Turn on house description once a button is clicked
        if (vamp_housing_infoNum > -1)
        {
            if (!obj_vampDesc.activeSelf)
            {
                obj_vampDesc.SetActive(true);
            }
        }

        if (human_housing_infoNum > -1)
        {
            if (!obj_humanDesc.activeSelf)
            {
                obj_humanDesc.SetActive(true);
            }
        }

        //Update the capacities of the buildings
        for (int a = 0; a < buildingTypes; a++)
        {
            vamp_housing_buildingTotalCap[a] = vamp_housing_buildingBaseCap[a] * vamp_housing_buildingAmount[a];
        }

        //Update total human production of each human building
        for (int a = 0; a < buildingTypes; a++)
        {
            human_housing_buildingTotalProduction[a] = human_housing_buildingBaseProduction[a] * human_housing_buildingAmount[a];
        }

        //Calculate Total Housing
        vamp_housing_amountTotal =
              vamp_housing_baseCap
            + vamp_housing_buildingTotalCap[0]
            + vamp_housing_buildingTotalCap[1]
            + vamp_housing_buildingTotalCap[2]
            + vamp_housing_buildingTotalCap[3]
            + vamp_housing_buildingTotalCap[4]
            + vamp_housing_buildingTotalCap[5]
            + vamp_housing_buildingTotalCap[6]
            + vamp_housing_buildingTotalCap[7]
            + vamp_housing_buildingTotalCap[8]
            + vamp_housing_buildingTotalCap[9];

        //Calculate Available Housing
        vamp_housing_amountAvailable = vamp_housing_amountTotal - vamp_housing_amountUsed;

        //Calculate Used Housing
        vamp_housing_amountUsed =
              VampireManager.vampires_amount_Total[0]
            + VampireManager.vampires_amount_Total[1]
            + VampireManager.vampires_amount_Total[2]
            + VampireManager.vampires_amount_Total[3]
            + VampireManager.vampires_amount_Total[4]
            + VampireManager.vampires_amount_Total[5]
            + VampireManager.vampires_amount_Total[6]
            + VampireManager.vampires_amount_Total[7]
            + VampireManager.vampires_amount_Total[8]
            + VampireManager.vampires_amount_Total[9];

        //Update UI Text [Lair]
        textBox_housingLair.text = sn.shortenNumber(vamp_housing_amountUsed, sn.shortenMethod, 2) + "/" + sn.shortenNumber(vamp_housing_amountTotal, sn.shortenMethod, 2);

        //Update all houses' button lock
        for (int a = 0; a < buildingTypes - 1; a++)
        {
            //vamp house buttons
            if (vamp_housing_buildingAmount[a] > 0 && vamp_building_unlocked[a + 1] == false)
            {
                vamp_building_unlocked[a + 1] = true;
            }

            //-------------------------------------------
            //human house buttons
            if (human_housing_buildingAmount[a] > 0 && human_building_unlocked[a + 1] == false)
            {
                human_building_unlocked[a + 1] = true;
            }
        }

        //Update all houses' visibility depending on lock
        for (int a = 0; a < buildingTypes; a++)
        {
            //Check if button is unlocked, if yes show it, if no, hide it.
            if (vamp_building_unlocked[a])
            {
                vamp_house_button[a].gameObject.SetActive(true);
            }
            else
            {
                vamp_house_button[a].gameObject.SetActive(false);
            }

            //Check if button is unlocked, if yes show it, if no, hide it.
            if (human_building_unlocked[a])
            {
                human_house_button[a].gameObject.SetActive(true);
            }
            else
            {
                human_house_button[a].gameObject.SetActive(false);
            }
        }
    }

    //Getters

    public double getHumanProduction()
    {
        double totalHumanProduction = 0;

        for (int a = 0; a < buildingTypes; a++)
        {
            totalHumanProduction += human_housing_buildingTotalProduction[a];
        }
        //Debug.Log("Total Human Production: " + totalHumanProduction + " per second");
        return totalHumanProduction;
    }
}