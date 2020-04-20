using NumberShortening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //Persistent (contains game stats)
{
    /*Declaration of Variables*/

    //Game Objects
    public TextMeshProUGUI textBox_Blood;

    public TextMeshProUGUI textBox_HumanPop;

    public TextMeshProUGUI textBox_Wood; //in building tab

    public TextMeshProUGUI textBox_Stone; //in building tab

    public TextMeshProUGUI textBox2_Wood; //in labor tab

    public TextMeshProUGUI textBox2_Stone;  //in labor tab

    public HousingManager HousingManager;

    //Class Objects
    private ShortenNumber sn = new ShortenNumber();

    //Panel Number Variable (0 = Lair, 1 = Buildings, and so on and so forth)
    public int panelNum;

    //Content GameObjects (for mass enabling and disabling)
    public Button[] panel_Button;

    public GameObject[] panel_Content;

    public GameObject resourcePanel; //move accordingly to fit panel layout

    //Resources
    public double res_Blood;

    public double res_Wood;
    public double res_Stone;
    public double res_HumanPop;

    //Cooldown Tick for Bite Button
    public int cooldownTick;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("UpdateResources");
    }

    // Update is called once per frame
    private void Update()
    {
        //Update Resource UI

        //Persistent
        textBox_Blood.text = sn.shortenNumber(res_Blood, sn.shortenMethod, 2);
        textBox_HumanPop.text = sn.shortenNumber(res_HumanPop, sn.shortenMethod, 2);

        //Building tab
        textBox_Wood.text = sn.shortenNumber(res_Wood, sn.shortenMethod, 2);
        textBox_Stone.text = sn.shortenNumber(res_Stone, sn.shortenMethod, 2);

        //Labor tab
        textBox2_Wood.text = sn.shortenNumber(res_Wood, sn.shortenMethod, 2);
        textBox2_Stone.text = sn.shortenNumber(res_Stone, sn.shortenMethod, 2);

        //Update Panel Buttons (Selected or not selected - Panel Buttons e.g. Lair, Buildings, Labor, etc.)
        for (int a = 0; a < panel_Button.Length; a++)
        {
            if (panelNum == a) //if selected
            {
                panel_Button[a].enabled = false;
                panel_Button[a].interactable = false;
                panel_Content[a].SetActive(true);
            }
            else //if not selected
            {
                panel_Button[a].enabled = true;
                panel_Button[a].interactable = true;
                panel_Content[a].SetActive(false);
            }
        }
    }

    private IEnumerator UpdateResources()
    {
        while (true)
        {
            addHumans();
            yield return new WaitForSeconds(1f);
        }
    }

    public void addHumans() //to be revised
    {
        res_HumanPop += (1 + HousingManager.getHumanProduction());
    }

    /* Panel Button Methods */

    public void SwitchLair()
    {
        panelNum = 0;
    }

    public void SwitchBuildings()
    {
        panelNum = 1;
    }

    public void SwitchLabor()
    {
        panelNum = 2;
    }

    public void SwitchUpgrades()
    {
        panelNum = 3;
    }

    public void SwitchBattle()
    {
        panelNum = 4;
    }

    public void SwitchOptions()
    {
        panelNum = 5;
    }
}