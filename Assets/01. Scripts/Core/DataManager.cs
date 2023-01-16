using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance = null;
    public static DataManager Instance {
        get {
            if(instance == null)
                instance = FindObjectOfType<DataManager>();

            return instance;
        }
    }

    private string saveFolderPath = "/Save";

    public UserSetting userSetting = null;

    private void Awake()
    {
        saveFolderPath = Application.persistentDataPath + saveFolderPath;
        if(instance != null)
            return;

        instance = this;

        if (!Directory.Exists(saveFolderPath)) Directory.CreateDirectory(saveFolderPath);

        userSetting = InitialData<UserSetting>();
    }

    private T InitialData<T>() where T : Data, new()
    {
        if(!TryReadJson<T>(out T data))
        {
            data = new T();
            data.Generate();
        }

        return data;
    }

    private bool TryReadJson<T>(out T data) where T : Data
    {
        string json = File.ReadAllText(GetPath<T>());

        if (json.Length > 0)
        {
            data = JsonConvert.DeserializeObject<T>(json);

            if(data.IsNull())
            {
                data = default(T);
                return false;
            }

            return true;
        }
        else
        {
            data = default(T);
            return false;
        }
    }

    public void SaveData<T>(T data) where T : Data
    {
        data.Save();

        string json = JsonConvert.SerializeObject(data);

        File.WriteAllText(GetPath<T>(), json);
    }

    private string GetPath<T>()
    {
        string path = $"{saveFolderPath}/{typeof(T)}.json";

        if(!File.Exists(path)) File.Create(path).Close();

        return path;
    }
}