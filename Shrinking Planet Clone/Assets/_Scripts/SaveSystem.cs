using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    const string SAVES_PATH = "/saves";

    // Save requires a key for a path and an object
    // We're saving in binary format
    // Object has to be serializable
    public static void Save<T>(T data, string key)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        
        // Different operating systems require different path, that's why we use Application.persistentDataPath, so we could throw this problem out the window
        string path = Application.persistentDataPath + SAVES_PATH;
        
        // Creates all directories and subdirectories in the specified path unless they already exist.
        Directory.CreateDirectory(path);

        FileStream fileStream = new FileStream(path + key, FileMode.Create);

        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static T Load<T>(string key)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        string path = Application.persistentDataPath + SAVES_PATH;

        // Default value for whatever type was passed in
        T data = default;

        if (File.Exists(path + key))
        {
            FileStream fileStream = new FileStream(path + key, FileMode.Open);

            data = (T)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }
        else
        {
            Debug.LogError($"Save not found in {path + key}");
        }

        return data;
    }

    public static bool SaveExists(string key)
    {
        string path = Application.persistentDataPath + SAVES_PATH;

        return File.Exists(path + key);
    }
}
