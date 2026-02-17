using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ObstacleSpawn obstacleSpawn; 
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button reStartButton;
    [SerializeField] public bool isGameOver;
    [SerializeField] public GameObject GamePlayPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI highestScore;
    [SerializeField] private TextMeshProUGUI currentScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            isGameOver = false;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

           
    }
    private void Start()
    {

        gameOverPanel.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        reStartButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    public void GameOver()
    {
        if (isGameOver)
            return;
        isGameOver = true;

        gameOverPanel.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        reStartButton.gameObject.SetActive(true);
        obstacleSpawn.StopCoroutine();
        DisableScoreHralth();
        SetCurrentScore();
        SetHighestScore();
    }
    public void Restart()
    {
        isGameOver = false;

        gameOverPanel.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        reStartButton.gameObject.SetActive(false);

        //ScoreManager.instance.ResetScore();
        //HealthManager.instance.ResetHealth();
        ShowGamePlayPanel();

    }
    public void ShowGamePlayPanel()
    {
        GamePlayPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }
    public void OffGamePlayPanel()
    {
        GamePlayPanel.SetActive(false);
    }
    public void ShowScoreHealth()
    {
        OffGamePlayPanel();
        HealthManager.instance.ResetHealth();
        ScoreManager.instance.ResetScore();
    }
    public void DisableScoreHralth()
    {
        HealthManager.instance.HideHealth();
        ScoreManager.instance.HideScore();
    }
    public void SetCurrentScore()
    {
        int CurrentScore = ScoreManager.instance.GetCurrentScore();
        currentScore.text = "Current Score \n       " + CurrentScore;

    }
    public void SetHighestScore()
    {
        ScoreManager.instance.CheckAndSaveHighScore();
        int highScore = ScoreManager.instance.HighScore();
        highestScore.text = "highest Score \n       " + highScore;
        

    }

}

