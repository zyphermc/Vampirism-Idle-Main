using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VampInputManager : MonoBehaviour //Local (Slider and Input field for Lair Tab)
{
    public GameManager GameManager;
    public VampireManager VampireManager;

    public Slider slider;

    public TMP_InputField inputField;

    public int killMethod; //0 Feed, 1 Infect
    public int vampIndex;

    //For setting percentage text in UI
    public TextMeshProUGUI textBox_TitlePercentage;


    private void Update()
    {

        //Set percentages
        if(killMethod == 0) //Slider Feed
        {

            slider.maxValue = VampireManager.slider_maxValue - VampireManager.slider_usedInfect[vampIndex]; //set the max value possible

            VampireManager.slider_usedFeed[vampIndex] = (int)slider.value; //update the set percentage in vamp manager

            //Set the percentage text
            textBox_TitlePercentage.text = "Feed (" + slider.value + "%)";
        }

        if(killMethod == 1)//Slider Infect
        {
            slider.maxValue = VampireManager.slider_maxValue - VampireManager.slider_usedFeed[vampIndex]; //set the max value possible

            VampireManager.slider_usedInfect[vampIndex] = (int)slider.value; //update the set percentage in vamp manager

            //Set the percentage text
            textBox_TitlePercentage.text = "Infect (" + slider.value + "%)";
        }
        
    }
}
