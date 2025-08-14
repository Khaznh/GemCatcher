using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    public static ScoreManager Instance { get ; private set; }
    private int playerScore = 0;
    private int gameTimer = 120;
    public bool gameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Debug.LogError("More than one Score Manager exsisted");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();

        if (!gameOver && gameTimer <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
    }

    public void RemoveScore(int amount)
    {
        playerScore -= amount;
    }
    public void DoubleScore()
    {
        playerScore = playerScore * 2;
    }

    public void TripScore()
    {
        playerScore = playerScore * 3;
    }

    public void FourScore()
    {
        playerScore = playerScore * 4;
    }

    public void AddGameTime(int amount)
    {
        gameTimer += amount;
    }

    public void ReduceGameTime(int amount)
    {
        gameTimer -= amount;
    }

    private void ShowScore()
    {
        scoreText.text = "Score: " + playerScore + " | Time: " + gameTimer;
    }

    private IEnumerator CountDownTimer()
    {
        while (gameTimer > 0)
        {
            yield return new WaitForSeconds(1);
            gameTimer--;
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game over \nScore: " + playerScore;
        gameOver = true;
    }
}
