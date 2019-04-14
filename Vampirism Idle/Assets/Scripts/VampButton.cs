using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VampButton : MonoBehaviour //Local
{
    public VampInfoWindow VampInfoWindow; //window of vampire info
    public StatisticsWindow StatisticsWindow; //window of statistics

    public Button vampButton;
    public int vampInfoNum;


    public void openVampInfo()
    {
        if (!VampInfoWindow.isActiveAndEnabled)
        {
            VampInfoWindow.gameObject.SetActive(true);
            StatisticsWindow.gameObject.SetActive(false);
            VampInfoWindow.vampIndex = vampInfoNum;
        }
        else
        {
            VampInfoWindow.vampIndex = vampInfoNum;
        }  
    }

    private void Update()
    {
        if(VampInfoWindow.vampIndex == vampInfoNum)
        {
            vampButton.interactable = false;
        }
        else
        {
            vampButton.interactable = true;
        }
    }
}
