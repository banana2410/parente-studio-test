using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//Save system that isn't implemented
public static class SaveSystem 
{
    //Save data and close stream after it
    public static void SaveStats(Progress progress)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.banana";
        FileStream stream = new FileStream(path, FileMode.Create);

        Progress data = new Progress(progress);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Return saved data from the path and close the stream after it
    public static Progress LoadStats()
    {
        string path = Application.persistentDataPath + "/stats.banana";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Progress data = formatter.Deserialize(stream) as Progress;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
