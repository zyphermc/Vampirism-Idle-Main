using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour //Persistent
{
    /*Declaration of Variables*/

    //Game Objects
    public TextMeshProUGUI textBox_Blood;
    public TextMeshProUGUI textBox_HumanPop;


    //Resources
    public double res_Blood;
    public double res_Wood;
    public double res_Stone;
    public double res_HumanPop;
    
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textBox_Blood.text = Math.Floor(res_Blood).ToString();
        textBox_HumanPop.text = Math.Floor(res_HumanPop).ToString();
    }
}
