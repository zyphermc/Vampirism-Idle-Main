using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //Object References for constructor - add here the objects to reference to get values
    public GameManager gameManager;

    public VampireManager vampireManager;
    public EfficiencyUpgrades efficiencyUpgrades;
    public HousingManager housingManager;
    public LaborManager laborManager;

    //------------------------------------

    [DllImport("__Internal")]
    private static extern void SyncFiles();

    [DllImport("__Internal")]
    private static extern void WindowAlert(string message);

    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter(); //formats data into binary
        string path = Application.persistentDataPath + "/playerData.zyp"; //path where binary file is to be located/created

        try
        {
            FileStream stream = new FileStream(path, FileMode.Create); //automatically closes the filestream after code block is run

            PlayerData data = new PlayerData(gameManager, vampireManager, efficiencyUpgrades, housingManager, laborManager); //create an instance of PlayerData to access its content (so that I don't have to drag it as a component reference)

            formatter.Serialize(stream, data);
            stream.Close();

            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                SyncFiles();
            }
        }
        catch (Exception e)
        {
            PlatformSafeMessage("Failed to Save: " + e.Message);
        }
    }

    public PlayerData LoadData()
    {
        PlayerData data = null;
        string path = Application.persistentDataPath + "/playerData.zyp";

        try
        {
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream stream = new FileStream(path, FileMode.Open);

                data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
            }
            return data;
        }
        catch (Exception e)
        {
            PlatformSafeMessage("Failed to Load: " + e.Message);
            return null;
        }
    }

    private static void PlatformSafeMessage(string message)
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            WindowAlert(message);
        }
        else
        {
            Debug.Log(message);
        }
    }
}