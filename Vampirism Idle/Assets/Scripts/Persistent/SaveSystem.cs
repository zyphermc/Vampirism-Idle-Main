using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //Object References for constructor
    public GameManager GameManager;

    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter(); //formats data into binary
        string path = Application.persistentDataPath + "/playerData.zyp"; //path where binary file is to be located/created

        using (FileStream stream = new FileStream(path, FileMode.Create)) //automatically closes the filestream after code block is run
        {
            PlayerData data = new PlayerData(GameManager); //create an instance of PlayerData to access its content (so that I don't have to drag it as a component reference)

            formatter.Serialize(stream, data);
        }
    }

    public PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.zyp";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                return data;
            }
        }
        else
        {
            Debug.LogError("Save file not found in path: " + path);
            return null;
        }
    }
}