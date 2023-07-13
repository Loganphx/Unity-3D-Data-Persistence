using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_InputField nameInputText;
    [SerializeField] private UnityEngine.UI.Button startButton;
    [SerializeField] private UnityEngine.UI.Button quitButton;

    private void Start()
    {
        nameInputText.onValueChanged.AddListener(SaveName);
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(Quit);

        scoreText.text = $"Best Score: {DataManager.Instance.PlayerName} : {DataManager.Instance.HighScore}";
    }

    private void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    private void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void SaveName(string value)
    {
        DataManager.Instance.SaveName(value);
        scoreText.text = $"Best Score: {DataManager.Instance.PlayerName} : {DataManager.Instance.HighScore}";
    }
}