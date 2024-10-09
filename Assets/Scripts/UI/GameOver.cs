using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(ExitToMainMenu);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ExitToMainMenu);
    }

    public void Setup(int score)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        _scoreText.text = "Очки: " + score.ToString();
    }


    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
