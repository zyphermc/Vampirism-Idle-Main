using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HousingButton : MonoBehaviour
{

    public Button housing_Button;
    public HousingBuyButton HousingBuyButton;
    public int housing_infoNum;
    public int descSwitch; //0 if vampire, 1 if human housing

    public HousingDescription HousingDescription;

    public HousingManager HousingManager;
    public TextMeshProUGUI buttonName;

    public void openHousingInfo()
    {
        HousingDescription.descSwitch = descSwitch;
        HousingDescription.housing_infoNum = housing_infoNum;
        HousingBuyButton.housing_infoNum = housing_infoNum;
    }

    private void Update()
    {

        if (descSwitch == 0)
        {
            buttonName.text = HousingManager.vamp_housing_buildingName[housing_infoNum];
        }
        else if (descSwitch == 1)
        {
            buttonName.text = HousingManager.human_housing_buildingName[housing_infoNum];
        }

        //If selected, darken.
        if (HousingDescription.housing_infoNum == housing_infoNum)
        {
            housing_Button.interactable = false;
        }
        else
        {
            housing_Button.interactable = true;
        }
    }
}
