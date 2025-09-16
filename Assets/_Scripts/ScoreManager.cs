using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private GameController gameController;
    public static ScoreManager Instance { get ; private set; }
    [SerializeField] private int playerScore = 0;
    [SerializeField] private int gameTimer = 120;
    [SerializeField] private int goal = 10;
    public bool isWin = false;

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
        ShowTime();
        ShowGoal();

        if (gameTimer <= 0)
        {
            isWin = IsWin();

            if (isWin)
            {
                gameController.LevelComplete();
            } else
            {
                gameController.GameOver();
            }
        }
    }
     
    private bool IsWin()
    {
        return playerScore >= goal;
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
    }

    public void RemoveScore(int amount)
    {
        playerScore -= amount;

        if (playerScore <= 0)
        {
            playerScore = 0;
        }
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
        scoreText.text = $"{playerScore}";
    }

    private void ShowTime()
    {
        timeText.text = "Time: " + gameTimer;
    }

    private void ShowGoal()
    {
        goalText.text = "Goal: " + goal;
    }

    private IEnumerator CountDownTimer()
    {
        while (gameTimer > 0)
        {
            yield return new WaitForSeconds(1);
            gameTimer--;
        }
    }
}
