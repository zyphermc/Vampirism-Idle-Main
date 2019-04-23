using TMPro;
using UnityEngine;

public class HousingManager : MonoBehaviour
{
    //Object References
    public VampireManager VampireManager;

    public TextMeshProUGUI textBox_housingLair;

    //Declaration of housing variables
    public int housing_amountAvailable;

    public int housing_amountTotal;
    public int housing_amountUsed;

    [HideInInspector] public string[] housing_buildingName;
    [HideInInspector] public string[] housing_buildingDesc;
    public int[] housing_buildingBaseCap;
    public int[] housing_buildingAmount;
    [HideInInspector] public int[] housing_buildingTotalCap;

    private void Start()
    {
        housing_buildingName[0] = "Tent";
        housing_buildingDesc[0] = "A small tent built with sticks";
        housing_buildingBaseCap[0] = 10;

        housing_buildingName[1] = "Small Shack";
        housing_buildingDesc[1] = "A small shack built with sticks";
        housing_buildingBaseCap[1] = 50;

        housing_buildingName[2] = "Big Shack";
        housing_buildingDesc[2] = "A big shack built with sticks";
        housing_buildingBaseCap[2] = 100;
    }

    private void Update()
    {
        //Update the capacities of the buildings
        for (int a = 0; a < housing_buildingName.Length; a++)
        {
            housing_buildingTotalCap[a] = housing_buildingBaseCap[a] * housing_buildingAmount[a];
        }

        //Calculate Total Housing
        housing_amountTotal =
              housing_buildingTotalCap[0]
            + housing_buildingTotalCap[1]
            + housing_buildingTotalCap[2]
            + housing_buildingTotalCap[3]
            + housing_buildingTotalCap[4]
            + housing_buildingTotalCap[5]
            + housing_buildingTotalCap[6]
            + housing_buildingTotalCap[7]
            + housing_buildingTotalCap[8]
            + housing_buildingTotalCap[9];

        //Calculate Available Housing
        housing_amountAvailable = housing_amountTotal - housing_amountUsed;

        //Calculate Used Housing
        housing_amountUsed =
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
        textBox_housingLair.text = housing_amountUsed + "/" + housing_amountTotal;
    }
}