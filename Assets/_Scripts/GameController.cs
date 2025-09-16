using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject levelCompletePanel;

    [SerializeField] private GameObject pauseButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void GameOver()
    {
        pauseButton.SetActive(false);
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelComplete()
    {
        pauseButton.SetActive(false);
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
