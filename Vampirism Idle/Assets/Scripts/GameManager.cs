using System;
using System.Collections;
using TMPro;
using UnityEngine;
using NumberShortening;

public class GameManager : MonoBehaviour //Persistent (contains game stats)
{
    /*Declaration of Variables*/

    //Game Objects
    public TextMeshProUGUI textBox_Blood;

    public TextMeshProUGUI textBox_HumanPop;

    //Class Objects
    ShortenNumber sn = new ShortenNumber();

    //Resources
    public double res_Blood;

    public double res_Wood;
    public double res_Stone;
    public double res_HumanPop;

    //Cooldown Tick for Bite Button
    public int cooldownTick;

    //experimental variables
    public double value;
    [HideInInspector] double tempValue;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("UpdateResources");

        
    }

    // Update is called once per frame
    private void Update()
    {
        textBox_Blood.text = Math.Floor(res_Blood).ToString();
        textBox_HumanPop.text = Math.Floor(res_HumanPop).ToString();;

        //experimental
        if(tempValue != value)
        {
            tempValue = value;
            Debug.Log(sn.shortenNumber(tempValue,0));
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

    public void addHumans()
    {
        res_HumanPop += 1;
    }
}