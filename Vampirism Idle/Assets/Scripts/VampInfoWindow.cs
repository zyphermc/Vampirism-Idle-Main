using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampInfoWindow : MonoBehaviour //Local (UI only)
{
    //Reference to Objects
    public VampireManager VampireManager; //contains vampire stats

    public StatisticsWindow StatisticsWindow; //window of statistics

    //Tabs
    public GameObject tab_killMethods;

    public GameObject tab_efficiencyUpgrades;

    //Textboxes
    public TextMeshProUGUI textBox_vampTitle;

    public TextMeshProUGUI textBox_vampQuote;
    public TextMeshProUGUI textBox_vampDesc;
    public TextMeshProUGUI textBox_vampAvailable;
    public TextMeshProUGUI textBox_vampStats;

    public TextMeshProUGUI textBox_infectTitle; //to be disabled when fledgeling is selected

    //Sliders and Input Fields
    public Slider slider_Feed;

    public Slider slider_Infect;
    public TMP_InputField inputField_Feed;
    public TMP_InputField inputField_Infect;

    public int vampIndex;
    [HideInInspector] public int page;

    private void Start()
    {
        page = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (vampIndex >= 0) //if vamp index is not -1
        {
            //Set Title, Quote, Description, and amount available
            textBox_vampTitle.text = VampireManager.vampires_name[vampIndex];
            textBox_vampQuote.text = VampireManager.vampires_quote[vampIndex];
            textBox_vampDesc.text = VampireManager.vampires_desc[vampIndex];

            if (page == 1) //kill methods page
            {
                textBox_vampAvailable.text = "Available: " + VampireManager.vampires_amount_Available_Total[vampIndex].ToString(); //update available vamps

                if (vampIndex >= 1) //if not fledgeling (since fledgeling can't infect so should not have any infection related shit)
                {
                    textBox_vampStats.text = "Blood per Feed: " + VampireManager.vampires_bloodPerKill[vampIndex].ToString("F2") + "\n"
                    + "Blood per Infect: " + VampireManager.vampires_bloodPerInfect[vampIndex].ToString("F2") + "\n"
                    + "Infection Chance: " + VampireManager.vampires_infectionChance[vampIndex] + "%" + "\n"
                    + "Efficiency: " + VampireManager.vampires_bloodEfficiency[vampIndex] + "%" + "\n"
                    + "Speed: " + VampireManager.vampires_completionTime[vampIndex] + " seconds";
                }
                else if (vampIndex == 0)
                {
                    textBox_vampStats.text = "Blood per Feed: " + VampireManager.vampires_bloodPerKill[vampIndex].ToString("F2") + "\n"
                    + "Efficiency: " + VampireManager.vampires_bloodEfficiency[vampIndex] + "%" + "\n"
                    + "Speed: " + VampireManager.vampires_completionTime[vampIndex] + " seconds";
                }

                //Turn off infection sliders and other stuff related to infection for Fledgelingss
                if (vampIndex == 0)
                {
                    slider_Infect.gameObject.SetActive(false);
                    inputField_Infect.gameObject.SetActive(false);
                    textBox_infectTitle.gameObject.SetActive(false);
                }
                else if (vampIndex >= 1)
                {
                    slider_Infect.gameObject.SetActive(true);
                    inputField_Infect.gameObject.SetActive(true);
                    textBox_infectTitle.gameObject.SetActive(true);
                }
            }
            else
            if (page == 2) //efficiency upgrades page
            {
                //insert description of buttons when hovered here
            }
        }
    }

    public void SwitchPage()
    {
        if (page == 1)
        {
            page = 2;
            tab_killMethods.SetActive(false);
            tab_efficiencyUpgrades.SetActive(true);
        }
        else
        {
            page = 1;
            tab_killMethods.SetActive(true);
            tab_efficiencyUpgrades.SetActive(false);
        }
    }

    public void CloseWindow()
    {
        vampIndex = -1;
        this.gameObject.SetActive(false);
        StatisticsWindow.gameObject.SetActive(true);
    }
}