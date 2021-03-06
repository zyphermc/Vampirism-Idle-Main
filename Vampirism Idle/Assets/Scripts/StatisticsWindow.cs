﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsWindow : MonoBehaviour //Local (UI)
{
    public GameManager GameManager;

    public TextMeshProUGUI textBox_Title;
    public TextMeshProUGUI textBox_Log;
    public TextMeshProUGUI textBox_Statistics;

    //String list
    private List<int> hourList = new List<int>();

    private List<int> minuteList = new List<int>();
    private List<string> eventList = new List<string>(); //contains each line of text

    private int maxLines;

    //Tab GameObjects
    public GameObject obj_Log;

    public GameObject obj_Statistics;

    public Button button_LogSwitch;
    public Button button_StatisticsSwitch;

    private void Start()
    {
        StartCoroutine("UpdateText");
        button_LogSwitch.interactable = false;

        //Max lines for log
        maxLines = 100;
    }

    private IEnumerator UpdateText()
    {
        while (true)
        {
            //Update Statistics Text
            textBox_Statistics.text = "Total Vampires: " + "" + "\n" + "Total Humans Killed: ";

            yield return new WaitForSeconds(1f);
        }
    }

    //Tab Switching for Button
    public void switchToLog()
    {
        if (!obj_Log.activeSelf)
        {
            obj_Statistics.SetActive(false);
            obj_Log.SetActive(true);
            button_LogSwitch.interactable = false;
            button_StatisticsSwitch.interactable = true;
            textBox_Title.text = "Log";
        }
    }

    public void switchToStatistics()
    {
        if (!obj_Statistics.activeSelf)
        {
            obj_Statistics.SetActive(true);
            obj_Log.SetActive(false);
            button_LogSwitch.interactable = true;
            button_StatisticsSwitch.interactable = false;
            textBox_Title.text = "Statistics";
        }
    }

    public void AddEvent(string eventString)
    {
        //Add a string to the list
        eventList.Add(eventString);
        hourList.Add(DateTime.Now.Hour);
        minuteList.Add(DateTime.Now.Minute);

        //If limit is reached, delete the farthest line
        if (eventList.Count >= maxLines)
        {
            eventList.RemoveAt(0);
            hourList.RemoveAt(0);
            minuteList.RemoveAt(0);
        }

        //Update Log Text
        textBox_Log.text = "";

        /*foreach (string logEvent in eventList)
        {
            textBox_Log.text += logEvent;
            textBox_Log.text += "\n";
        }*/

        for (int a = 0; a < eventList.Count; a++)
        {
            textBox_Log.text += "[" + hourList[a].ToString("00") + ":" + minuteList[a].ToString("00") + "] " + eventList[a];
            textBox_Log.text += "\n";
        }
    }
}