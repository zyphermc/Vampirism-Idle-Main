using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        if (descSwitch == 0)
        {
            HousingManager.vamp_housing_infoNum = housing_infoNum;
        }
        else
        if (descSwitch == 1)
        {
            HousingManager.human_housing_infoNum = housing_infoNum;
        }

        HousingBuyButton.housing_infoNum = housing_infoNum;
    }

    private void Update()
    {
        if (descSwitch == 0)
        {
            buttonName.text = HousingManager.vamp_housing_buildingName[housing_infoNum];

            //If selected, darken.
            if (HousingManager.vamp_housing_infoNum == housing_infoNum)
            {
                housing_Button.interactable = false;
            }
            else
            {
                housing_Button.interactable = true;
            }
        }
        else if (descSwitch == 1)
        {
            buttonName.text = HousingManager.human_housing_buildingName[housing_infoNum];

            //If selected, darken.
            if (HousingManager.human_housing_infoNum == housing_infoNum)
            {
                housing_Button.interactable = false;
            }
            else
            {
                housing_Button.interactable = true;
            }
        }
    }
}