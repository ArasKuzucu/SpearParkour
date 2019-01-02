using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   
    public static void SavePlayerProgress(GameManager gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.canIjoinTheTeam";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.canIjoinTheTeam";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in" + path);
            return null;
        }
    }
}
