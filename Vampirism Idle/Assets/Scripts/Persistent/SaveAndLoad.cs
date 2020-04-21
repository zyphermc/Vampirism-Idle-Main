using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{

    public GameManager GameManager;
    public SaveSystem SaveSystem;

    //Save and Load Methods - Saves the current data to file, and Loads data from file then updating the current values
    public void Save()
    {
        SaveSystem.SaveData();
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadData();

        GameManager.res_Blood = data.res_Blood;
        GameManager.res_HumanPop = data.res_HumanPop;
        GameManager.res_Wood = data.res_Wood;
        GameManager.res_Stone = data.res_Stone;
    }
}
