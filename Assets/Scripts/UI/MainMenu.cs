using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private Button _startButton;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartGame);
    }

    private void Start()
    {
        _highScoreText.text = "Очки: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
