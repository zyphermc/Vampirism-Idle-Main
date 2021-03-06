﻿using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    //Objects to reference to replace loaded data
    public GameManager GameManager;

    public VampireManager VampireManager;
    public EfficiencyUpgrades EfficiencyUpgrades;
    public HousingManager HousingManager;
    public LaborManager LaborManager;

    public SaveSystem SaveSystem; //Save System Object

    public bool updatedSliderValueFeed = false; //Switch to update slider value using player data to avoid overriding player data slider value with current slider value
    public bool updatedSliderValueInfect = false;

    private void Start()
    {
        //Load(); //Loads save at startup
    }

    //Save and Load Methods - Saves the current data to file, and Loads data from file then updating the current values
    public void Save()
    {
        SaveSystem.SaveData();
        Debug.Log("Data saved successfully.");
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadData();
        Debug.Log("Data loaded successfully.");

        //Switches for updating slider values in feed and infect
        updatedSliderValueFeed = false;
        updatedSliderValueInfect = false;

        #region Resources

        GameManager.res_Blood = data.res_Blood;
        GameManager.res_HumanPop = data.res_HumanPop;
        GameManager.res_Wood = data.res_Wood;
        GameManager.res_Stone = data.res_Stone;

        #endregion Resources

        #region Vampire Data

        for (int a = 0; a < 10; a++)
        {
            VampireManager.vampires_amount_Total[a] = data.vampires_amount_Total[a];
            VampireManager.vampires_unlocked[a] = data.vampires_unlocked[a];

            VampireManager.slider_savedMaxValueFeed[a] = data.slider_savedMaxValueFeed[a];
            VampireManager.slider_savedMaxValueInfect[a] = data.slider_savedMaxValueInfect[a];
            VampireManager.slider_usedFeed[a] = data.slider_usedFeed[a];
            VampireManager.slider_usedInfect[a] = data.slider_usedInfect[a];

            EfficiencyUpgrades.level_SharpenFang[a] = data.level_SharpenFang[a];
            EfficiencyUpgrades.level_TrainAgility[a] = data.level_TrainAgility[a];
        }

        #endregion Vampire Data

        #region Housing
        for (int a = 0; a < 10; a++)
        {
            HousingManager.vamp_housing_buildingAmount[a] = data.vamp_housing_buildingAmount[a];
            HousingManager.human_housing_buildingAmount[a] = data.human_housing_buildingAmount[a];
        }
        #endregion

        #region Labor

        LaborManager.fledgelings_used_wood = data.fledgelings_used_wood;
        LaborManager.fledgelings_used_stone = data.fledgelings_used_stone;

        #endregion Labor
    }
}