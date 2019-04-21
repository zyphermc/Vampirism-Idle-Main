using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AscendManager : MonoBehaviour //Local (calculates the cost, info text, and amount of vampires available to ascend)
{
    //Managers
    public GameManager GameManager;
    public VampireManager VampireManager;

    //Vamp Stats Text Box
    public TextMeshProUGUI textBox_ButtonInfo;

    public string AscendButtonInfo;

    //Ascend Button Info Switch
    public bool ascendAvailable; //if there is n amount of vamps, make it true.
    public bool showAscendInfo; //if ascend button is hovered.

    //Vampire Index
    public int vampIndex;

    private void Start()
    {
        showAscendInfo = false;
        ascendAvailable = true;
    }

    private void Update()
    {
        AscendButtonInfo = "Mah nem is jeff. " + "[" + vampIndex + "]";
    }

    public void ShowAscendInfo()
    {
        showAscendInfo = true;
        Debug.Log("showAscendInfo = true");
    }

    public void HideAscendInfo()
    {
        showAscendInfo = false;
        Debug.Log("showAscendInfo = false");
    }
}
