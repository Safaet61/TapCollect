using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ObstacleSpawn obstacleSpawn; 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button reStartButton;
    [SerializeField] public bool isGameOver;
    [SerializeField] public GameObject GamePlayPanel;

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
        ScoreManager.instance.scoreText.gameObject.SetActive(false);
    }
    public  void Restart()
    {
        isGameOver = false;

        gameOverPanel.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        reStartButton.gameObject.SetActive(false);

        ScoreManager.instance.ResetScore();
        HealthManager.instance.ResetHealth();
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
   
}

