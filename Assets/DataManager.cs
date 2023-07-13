using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    
    public string PlayerName { get; set; }
    public int HighScore { get; set; }
    
    public void SaveName(string name)
    {
        PlayerName = name;
        SaveToFile();
    }
    
    public void SaveHighScore(int score)
    {
        HighScore = score;
        SaveToFile();
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        LoadFromFile();
    }
    
    public class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }
    
    public void SaveToFile()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.HighScore = HighScore;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            PlayerName = data.PlayerName;
            HighScore = data.HighScore;
        }
    }
}