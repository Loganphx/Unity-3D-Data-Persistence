using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    
    public string PlayerName { get; set; }
    public int HighScore { get; set; }
    
    public void SaveName(string name)
    {
        PlayerName = name;
    }
    
    public void SaveHighScore(int score)
    {
        HighScore = score;
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
    }
}