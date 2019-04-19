using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VampButton : MonoBehaviour //Local
{
    public VampInfoWindow VampInfoWindow; //window of vampire info
    public StatisticsWindow StatisticsWindow; //window of statistics

    public VampInputManager VampInputManager_Feed;
    public VampInputManager VampInputManager_Infect;

    public Slider slider_Feed;
    public Slider slider_Infect;

    public VampireManager VampireManager;

    public Button vampButton;
    public int vampInfoNum;

    public void openVampInfo()
    {
        if (!VampInfoWindow.isActiveAndEnabled) //if vampire window is not yet opened
        {
            VampInfoWindow.gameObject.SetActive(true);
            StatisticsWindow.gameObject.SetActive(false);

            //Set the vampire index to the window and others
            VampInfoWindow.vampIndex = vampInfoNum;
            VampInputManager_Feed.vampIndex = vampInfoNum;
            VampInputManager_Infect.vampIndex = vampInfoNum;

            //Set the saved value to the sliders
            slider_Feed.value = VampireManager.slider_usedFeed[vampInfoNum];
            slider_Infect.value = VampireManager.slider_usedInfect[vampInfoNum];
        }
        else //if another vampire window is already open
        {
            //Set the vampire index to the window and others
            VampInfoWindow.vampIndex = vampInfoNum;
            VampInputManager_Feed.vampIndex = vampInfoNum;
            VampInputManager_Infect.vampIndex = vampInfoNum;

            //Set the saved value to the sliders
            slider_Feed.maxValue = VampireManager.slider_savedMaxValueFeed[vampInfoNum]; 
            slider_Feed.value = VampireManager.slider_usedFeed[vampInfoNum];

            slider_Infect.maxValue = VampireManager.slider_savedMaxValueInfect[vampInfoNum];
            slider_Infect.value = VampireManager.slider_usedInfect[vampInfoNum];
        }
    }

    private void Update()
    {
        if (VampInfoWindow.vampIndex == vampInfoNum)
        {
            vampButton.interactable = false;
        }
        else
        {
            vampButton.interactable = true;
        }
    }
}