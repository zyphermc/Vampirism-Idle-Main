using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class StatisticsWindow : MonoBehaviour //Local (UI)
{
    public GameManager GameManager;

    public TextMeshProUGUI textBox_Statistics;

    private void Start()
    {
        StartCoroutine("UpdateText");
    }

    private IEnumerator UpdateText()
    {
        textBox_Statistics.text = "Total Vampires: " + "" + "\n" + "Total Humans Killed: ";
        yield return new WaitForSeconds(1f);
    }
}
