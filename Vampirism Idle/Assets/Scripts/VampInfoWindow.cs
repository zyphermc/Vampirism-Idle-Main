using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class VampInfoWindow : MonoBehaviour //Local (UI only)
{
    //Reference to Objects
    public VampireManager VampireManager; //contains vampire stats
    public StatisticsWindow StatisticsWindow; //window of statistics

    //Textboxes
    public TextMeshProUGUI textBox_vampTitle;
    public TextMeshProUGUI textBox_vampQuote;
    public TextMeshProUGUI textBox_vampDesc;
    public TextMeshProUGUI textBox_vampAvailable;
    public TextMeshProUGUI textBox_vampStats;
    public int vampIndex;

    // Update is called once per frame
    void Update()
    {
        if(vampIndex >= 0) //if vamp index is not -1
        {
            textBox_vampTitle.text = VampireManager.vampires_name[vampIndex];
            textBox_vampQuote.text = VampireManager.vampires_quote[vampIndex];
            textBox_vampDesc.text = VampireManager.vampires_desc[vampIndex];
            textBox_vampAvailable.text = "Available: " + VampireManager.vampires_amount_Available_Total[vampIndex].ToString();

        }
        
    }

    public void CloseWindow()
    {
        vampIndex = -1;
        this.gameObject.SetActive(false);
        StatisticsWindow.gameObject.SetActive(true);
    }
}
